import { Base } from "./Base.model";

export class DoanhNghiepDichVuCA extends Base{  
    NhanVienID?: number;           
    DichVuID?: number;    
    NgayKyHopDong?: Date;    
    GiaTien?: number;
    SoThang?: number;
    MaThueBao?: string;
    DiaChiLapDat?: string;
    DichVuVienThong?: string;
    PhongBanID?: number;
    GoiCuocID?: number;
    UserName?: string;
    SoChungThu?: string;
    SubjectDN?: string;
    NgayHieuLuc?: Date;
    NgayHetHan?: Date;
    NgayHetHanNguyenMau?: Date;
    SoNgayNoKhach?: number;
    TenGoiCuoc?: string;
    ThoiGianGoiCuoc?: number;
    ThoiGianKhuyenMai?: number;
    DienThoai?: string;
    Email?: string;
    TaiKhoanTaoYeuCau?: string;
    TaiKhoanDuyetYeuCau?: string;
    LoaiYeuCauID?: number;
    LoaiYeuCau?: string;
    TrangThaiChungThu?: string;
    LoaiTrangThaiID?: number;
    SoChungThuCu?: string;
    IDThucThe?: string;
    IDChungThu?: string;
    NguoiLienHe?: string;
    IDYeuCau?: string;
    DonVi?: string;
    MaNhanVien?: string;
    NhanVien?: string;
    IsHopDong?: boolean;
    HopDong?: string;
    IsDonXinCapChungThuSo?: boolean;
    DonXinCapChungThuSo?: string;
    IsGiayPhepKinhDoanh?: boolean;
    GiayPhepKinhDoanh?: string;
    IsBienBanNghiemThu?: boolean;
    BienBanNghiemThu?: string;
    IsHoaDon?: boolean;
    HoaDon?: string;
    IsCCCD?: boolean;
    CCCD?: string;
    IsKetLuan?: boolean;
    KetLuan?: string;
    IsCapBu?: boolean;
}
