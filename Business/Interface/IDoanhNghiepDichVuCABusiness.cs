namespace Business.Interface
{
	public interface IDoanhNghiepDichVuCABusiness : IBaseBusiness<DoanhNghiepDichVuCA>
	{
		Task<DoanhNghiepDichVuCA> Save001Async(DoanhNghiepDichVuCA model);
	}
}
