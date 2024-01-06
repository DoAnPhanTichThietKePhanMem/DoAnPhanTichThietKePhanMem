using System.Collections.Generic;
using System;
using QLHS.DBContext;
using QLHS.ViewModel;
using System.Linq;

namespace QLHS.Repository
{
    public class ReportRepository:IReportRepository
    {
        private readonly iyjh6fZpyWContext _dbContext;
        public ReportRepository(iyjh6fZpyWContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ReportVM> BaoCaoTongKetMon(int SubjectID, int SemeterID)
        {
            var sl = SoluongDatMon(SubjectID, SemeterID);
            var tl = TiLeDatMon(SubjectID, SemeterID);
            var list = (from sb in _dbContext.TbSubjects
                        join ts in _dbContext.TbTranScripts on sb.Id equals ts.SubjectId
                        join st in _dbContext.TbStudents on ts.StudentId equals st.Id
                        join cl in _dbContext.TbClasses on st.ClassId equals cl.Id
                        join sm in _dbContext.TbSemesters on ts.SemesterId equals sm.Id
                        where (ts.IsDeleted == false && st.IsDeleted == false && ts.SemesterId == SemeterID && ts.SubjectId == SubjectID)
                        select new ReportVM
                        {
                            ClassID = st.ClassId,
                            ClassName = cl.Name,
                            SiSo = cl.Quantity,
                            SoLuongDat = sl,
                            TiLeDat = tl
                        }).Distinct().ToList();
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


        public List<ReportVM> BaoCaoTongKetHocKy(int SemeterID)
        {
            var sl = SoluongDatHK(SemeterID);
            var tl = TiLeDatHK(SemeterID);
            var list = (from sm in _dbContext.TbSemesters
                        join ts in _dbContext.TbTranScripts on sm.Id equals ts.SemesterId
                        join st in _dbContext.TbStudents on ts.StudentId equals st.Id
                        join cl in _dbContext.TbClasses on st.ClassId equals cl.Id
                        where (ts.IsDeleted == false && st.IsDeleted == false && ts.SemesterId == SemeterID)
                        select new ReportVM
                        {
                            ClassID = st.ClassId,
                            ClassName = cl.Name,
                            SiSo = cl.Quantity,
                            SoLuongDat = sl,
                            TiLeDat = tl
                        }).Distinct().ToList();
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

        private int SoluongDatMon(int SubjectID, int SemeterID)//, int ClassID
        {
            var rs = _dbContext.TbTranScripts.Where(x => x.IsDeleted == false && x.SubjectId == SubjectID && x.SemesterId == SemeterID && ((x.Grade15 + x.Grade45 * 2 + x.GradeSemester * 3) / 5) >= 5).ToList();
            return rs.Count;
        }
        private double TiLeDatMon(int SubjectID, int SemeterID)
        {
            var rs = _dbContext.TbTranScripts.Where(x => x.IsDeleted == false && x.SubjectId == SubjectID && x.SemesterId == SemeterID && ((x.Grade15 + x.Grade45 * 2 + x.GradeSemester * 3) / 5) >= 5).ToList();
            var total = _dbContext.TbTranScripts.Where(x => x.IsDeleted == false && x.SubjectId == SubjectID && x.SemesterId == SemeterID).ToList();
            if (total.Count != 0)
            {
                return Math.Round((rs.Count / total.Count) * 100.0);
            }
            return 0;
        }

        private int SoluongDatHK(int SemeterID)
        {
            var rs = _dbContext.TbTranScripts.Where(x => x.IsDeleted == false && x.SemesterId == SemeterID && ((x.Grade15 + x.Grade45 * 2 + x.GradeSemester * 3) / 5) >= 5).Count();
            return rs;
        }
        private double TiLeDatHK(int SemeterID)
        {
            double rs = _dbContext.TbTranScripts.Where(x => x.IsDeleted == false && x.SemesterId == SemeterID && ((x.Grade15 + x.Grade45 * 2 + x.GradeSemester * 3) / 5) >= 5).Count();
            double total = _dbContext.TbTranScripts.Where(x => x.IsDeleted == false && x.SemesterId == SemeterID).Count();
            if (total != 0)
            {
                return Math.Round((rs / total) * 100.0);
            }
            return 0;
        }
    }
}
