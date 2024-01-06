using QLHS.DBContext;
using System.Collections.Generic;
using QLHS.ViewModel;
using System.Linq;
using System;

namespace QLHS.Repository
{
    public class GradesRepository:IGradesRepository
    {
        private readonly iyjh6fZpyWContext _dbContext;
        public GradesRepository(iyjh6fZpyWContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<GradesVM> GetGradesList(int ClassID, int SemeterID, int SubjectID)
        {
            var list = (from st in _dbContext.TbStudents
                        join ts in _dbContext.TbTranScripts.DefaultIfEmpty() on st.Id equals ts.StudentId
                        join sm in _dbContext.TbSemesters.DefaultIfEmpty() on ts.SemesterId equals sm.Id
                        join sb in _dbContext.TbSubjects.DefaultIfEmpty() on ts.SubjectId equals sb.Id
                        where (ts.IsDeleted == false && st.IsDeleted == false && ts.SemesterId == SemeterID && ts.SubjectId == SubjectID)
                        select new GradesVM
                        {
                            ID = ts.Id,
                            StudentID = st.Id,
                            Name = st.Name,
                            SemesterID = ts.SemesterId ?? null,
                            Semester = sm.Name ?? null,
                            SubjectID = ts.SubjectId ?? null,
                            SubjectName = sb.Name ?? null,
                            Grade15 = ts.Grade15 ?? null,
                            Grade45 = ts.Grade45 ?? null,
                            GradeSemester = ts.GradeSemester ?? null
                        }).ToList();
            if (list.Count > 0)
            {
                int i = 1;
                foreach (var item in list)
                {
                    item.STT = i;
                    i++;
                }
            }
            return list;
        }

        public List<TbStudent> GetInfoStudentsOfClass(int classId)
        {
            var list = new List<TbStudent>(_dbContext.TbStudents.Where(st => st.ClassId == classId && st.IsDeleted == false).ToList());

            return list;
        }

        public List<TbSemester> GetInfoSemeters()
        {
            var list = new List<TbSemester>(_dbContext.TbSemesters.Where(s => s.IsDeleted == false).ToList());

            return list;
        }


        public bool AddGrades(TbTranScript ts)
        {
            _dbContext.TbTranScripts.Add(ts);
            return _dbContext.SaveChanges() > 0;
        }


        public bool UpdateGrades(TbTranScript ts)
        {
            var model = _dbContext.TbTranScripts.Where(x => x.Id == ts.Id && x.IsDeleted == false).Single();
            model.Grade15 = ts.Grade15;
            model.Grade45 = ts.Grade45;
            model.GradeSemester = ts.GradeSemester;
            model.LastUpdatedDate = DateTime.Now;

            _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _dbContext.SaveChanges() > 0;
        }

        public bool CheckGrades(TbTranScript ts)
        {
            var model = _dbContext.TbTranScripts.Where(x => x.StudentId == ts.SubjectId && x.SemesterId == ts.SemesterId && x.SubjectId == ts.SubjectId && x.IsDeleted == false).ToList();
            if (model.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool DeleteGrades(int ID)
        {
            var student = _dbContext.TbTranScripts.First(x => x.Id == ID);
            student.IsDeleted = true;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
