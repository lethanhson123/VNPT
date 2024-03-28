
namespace Business.Implement
{
	public class GoiCuocBusiness : BaseBusiness<GoiCuoc, IGoiCuocRepository>, IGoiCuocBusiness
	{
		private readonly IGoiCuocRepository _GoiCuocRepository;
		public GoiCuocBusiness(IGoiCuocRepository GoiCuocRepository) : base(GoiCuocRepository)
		{
			_GoiCuocRepository = GoiCuocRepository;
		}
		public override void Initialization(GoiCuoc model)
		{
			if (string.IsNullOrEmpty(model.Code))
			{
				model.Code = GlobalHelper.InitializationDateTimeCode;
			}
			model.Display = model.Name + "-" + model.Code;
			if ((model.SortOrder == null) || (model.SortOrder == GlobalHelper.InitializationNumber))
			{
				model.SortOrder = 1;
			}

			if (model.Thang != null)
			{
				model.ThangKhuyenMai = model.Thang + model.ThangKhuyenMai;
				switch (model.Thang)
				{
					case 12:
						model.ThangKhuyenMai = 18;
						break;
					case 24:
						model.ThangKhuyenMai = 36;
						break;
					case 36:
						model.ThangKhuyenMai = 48;
						break;                   
                }
			}
		}
	}
}
