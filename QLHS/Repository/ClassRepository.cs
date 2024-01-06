using QLHS.DBContext;
using QLHS.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Linq;

namespace QLHS.Repository
{
    public class ClassRepository:IClassRepository
    {
        private readonly iyjh6fZpyWContext _dbContext;
        public ClassRepository(iyjh6fZpyWContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Lấy thông tin khối lớp
        /// </summary>
        /// <returns></returns>
        public List<TbGroup> GetInfoGroup()
        {
            var list = new List<TbGroup>(_dbContext.TbGroups.Where(gr => gr.IsDeleted == false).ToList());
            return list;
        }

        /// <summary>
        /// Lấy thông tin lớp theo id
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public List<TbClass> GetInfoClass(int gradeId)
        {
            var list = new List<TbClass>(_dbContext.TbClasses.Where(cl => cl.GroupId == gradeId && cl.IsDeleted == false).ToList());

            return list;
        }

        /// <summary>
        /// Lấy thông tin lớp theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TbClass GetInfoClassByName(string name)
        {
            return _dbContext.TbClasses.FirstOrDefault(cl => cl.Name == name && cl.IsDeleted == false);
        }

        /// <summary>
        /// Lấy danh sách học sinh trong lớp theo mã lớp, tên
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="studentNameSearch"></param>
        /// <returns></returns>
        public List<TbStudent> GetInfoStudentsOfClass(GetInfoStudentsOfClassRequest input)
        {
            var list = new List<TbStudent>(_dbContext.TbStudents.Where(st => st.ClassId == input.ClassID && st.IsDeleted == false && st.Name.Contains(input.StudentNameSearch)).ToList());

            return list;
        }

        /// <summary>
        /// Lấy thông tin học sinh theo tên
        /// </summary>
        /// <param name="studentNameSearch"></param>
        /// <returns></returns>
        public List<TbStudent> GetInfoStudentsWithoutClass(string studentNameSearch)
        {
            var list = new List<TbStudent>(_dbContext.TbStudents.Where(st => st.ClassId == null && st.IsDeleted == false && st.Name.Contains(studentNameSearch==null?"": studentNameSearch)).ToList());

            return list;
        }

        /// <summary>
        /// Kiểm tra số lượng học sinh trong lớp
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="quantityStudentsAddToClass"></param>
        /// <returns></returns>
        public bool CheckQuantityStudentOfclass(CheckQuantityStudentOfclassRequest input)
        {
            var regulation = _dbContext.TbRegulations.Where(re => re.IsDeleted == false).FirstOrDefault();
            int? quantity = regulation.MaxQuantity;
            int? quantityCurrent = _dbContext.TbClasses.Where(cl => cl.Id == input.ClassID).Select(cl => cl.Quantity).Single();
            return quantity >= (quantityCurrent + input.QuantityStudentsAddToClass);
        }

        /// <summary>
        /// Thêm học sinh vào lớp
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool AddStudentIntoClass(AddStudentIntoClassRequest input)
        {
            var student = _dbContext.TbStudents.Single(st => st.Id == input.StudentID && st.IsDeleted == false);
            student.ClassId = input.ClassID;

            // Update quantity student.
            var classInfo = _dbContext.TbClasses.Single(cl => cl.Id == input.ClassID && cl.IsDeleted == false);
            classInfo.Quantity += 1;

            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Xóa học sinh khỏi lớp
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool DeleteStudentFromClass(int studentId)
        {
            var student = _dbContext.TbStudents.Single(st => st.Id == studentId && st.IsDeleted == false);
            var classInfo = _dbContext.TbClasses.Single(cl => cl.Id == student.ClassId && cl.IsDeleted == false);
            classInfo.Quantity -= 1;
            student.ClassId = null;

            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Tạo lớp mới
        /// </summary>
        /// <param name="newClass"></param>
        /// <returns></returns>
        public bool AddInfoClass(TbClass newClass)
        {
            _dbContext.TbClasses.Add(newClass);
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Cập nhật tên lớp học
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public bool UpdateInfoNameClass(UpdateInfoNameClassRequest input)
        {
            var classInfo = _dbContext.TbClasses.Single(st => st.Id == input.ClassID && st.IsDeleted == false);
            classInfo.Name = input.NewName;

            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Xóa lớp học
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public bool DeleteInfoClass(int classId)
        {
            var classInfo = _dbContext.TbClasses.Single(st => st.Id == classId);
            classInfo.IsDeleted = true;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
