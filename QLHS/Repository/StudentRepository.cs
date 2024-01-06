using QLHS.DBContext;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLHS.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly iyjh6fZpyWContext _dbContext;
        public StudentRepository(iyjh6fZpyWContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TbStudent> ListStudentRecord()
        {
            var listStudentRecord = new List<TbStudent>(_dbContext.TbStudents.Where(x => x.IsDeleted == false).Select(x => x).ToList());

            return listStudentRecord;
        }

        public List<TbStudent> SearchStudent(string stringSearch)
        {
            var listStudentSearch = new List<TbStudent>((from t in _dbContext.TbStudents
                                                         where t.IsDeleted == false && (t.Name.Contains(stringSearch) || t.Email.Contains(stringSearch) || t.Address.Contains(stringSearch))
                                                                           select t).ToList());
            return listStudentSearch;
        }

        public bool AddStudent(TbStudent Students)
        {
            _dbContext.TbStudents.Add(Students);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteStudent(int ID)
        {
            var student = _dbContext.TbStudents.First(x => x.Id == ID);
            student.IsDeleted = true;

            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateStudent(TbStudent students)
        {
            var student = _dbContext.TbStudents.Where(x => x.Id == students.Id).Single();
            student.Name = students.Name;
            student.Gender = students.Gender;
            student.DateOfBirth = students.DateOfBirth;
            student.Address = students.Address;
            student.Email = students.Email;
            students.LastUpdatedDate = DateTime.Now;

            _dbContext.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
