using Student.Entity.Student;


namespace Student.Business.Abstract
{
    public interface IFamiliesService : IBaseService<Family>
    {
        Task<bool> IsAlreadyAddedCode(string code);
    }
}
