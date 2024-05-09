using Microsoft.EntityFrameworkCore;
using QLViecLam.Models.Admin.Manages;
using QLViecLam.Models.Admin.Manages.DanhMuc;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;
using QLViecLam.Models.Admin.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QLViecLam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Systems
        public DbSet<Users> Users { get; set; }
        public DbSet<DmDonvi> DmDonvi { get; set; }
        public DbSet<DmHanhChinh> DmHanhChinh { get; set; }
        public DbSet<DsNhomTaiKhoan> DsNhomTaiKhoan { get; set; }
        public DbSet<DsNhomTaiKhoan_PhanQuyen> DsNhomTaiKhoan_PhanQuyen { get; set; }
        public DbSet<DsTaiKhoan_PhanQuyen> DsTaiKhoan_PhanQuyen { get; set; }

        //End Systems



        //Settings

        //End Settings



        //Manages
        //ThongTinThiTruongLD
        public DbSet<Company> Company { get; set; }
        public DbSet<DsThatNghiep> DsThatNghiep { get; set; }
        public DbSet<KyBaoCao> KyBaoCao { get; set; }
        public DbSet<NguoiLaoDong> NguoiLaoDong { get; set; }
        public DbSet<NhanKhau> NhanKhau { get; set; }
        public DbSet<TongHopCungLaoDong> TongHopCungLaoDong { get; set; }
        public DbSet<TuyenDung> TuyenDung { get; set; }
        public DbSet<ViTriTuyenDung> ViTriTuyenDung { get; set; }
        public DbSet<KeHoachThuThapThongTin> KeHoachThuThapThongTin { get; set; }
        //end ThongTinThiTruongLD
        //DanhMuc
        public DbSet<DmChucVu> DmChucVu { get; set; }
        public DbSet<DmDoiTuongUuTien> DmDoiTuongUuTien { get; set; }
        public DbSet<DmHinhThucLamViec> DmHinhThucLamViec { get; set; }
        public DbSet<DmLoaiHieuLucHdld> DmLoaiHieuLucHdld { get; set; }
        public DbSet<DmLoaiHinhHdkt> DmLoaiHinhHdkt { get; set; }
        public DbSet<DmLoaiLaoDong> DmLoaiLaoDong { get; set; }
        public DbSet<DmMangHeTrinhDo> DmMangHeTrinhDo { get; set; }
        public DbSet<DmNganhNghe> DmNganhNghe { get; set; }
        public DbSet<DmNganhSxkd> DmNganhSxkd { get; set; }
        public DbSet<DmNgheCongViec> DmNgheCongViec { get; set; }
        public DbSet<DmNguyenNhanThatNghiep> DmNguyenNhanThatNghiep { get; set; }
        public DbSet<DmTinhTrangThamGiaHdkt> DmTinhTrangThamGiaHdkt { get; set; }
        public DbSet<DmTinhTrangThamGiaHdktCt> DmTinhTrangThamGiaHdktCt { get; set; }
        public DbSet<DmTinhTrangThamGiaHdktCt2> DmTinhTrangThamGiaHdktCt2 { get; set; }
        public DbSet<DmTrinhDoGdpt> DmTrinhDoGdpt { get; set; }
        public DbSet<DmTrinhDoKyThuat> DmTrinhDoKyThuat { get; set; }
        public DbSet<DmQuocGia> DmQuocGia { get; set; }
        public DbSet<DmDoiTuongChinhSach> DmDoiTuongChinhSach { get; set; }
        public DbSet<DmHinhThucDaoTao> DmHinhThucDaoTao { get; set; }
        public DbSet<DmHinhThucDoanhNghiep> DmHinhThucDoanhNghiep { get; set; }
        public DbSet<DmHinhThucThamGia> DmHinhThucThamGia { get; set; }
        public DbSet<DmKhuCongNghiep> DmKhuCongNghiep { get; set; }
        public DbSet<DmLoaiHinhDaoTao> DmLoaiHinhDaoTao { get; set; }
        public DbSet<DmLoaiViecLam> DmLoaiViecLam { get; set; }
        public DbSet<DmNghanhHoc> DmNghanhHoc { get; set; }
        public DbSet<DmNgheDaoTao> DmNgheDaoTao { get; set; }
        public DbSet<DmNguonViecLam> DmNguonViecLam { get; set; }
        public DbSet<DmTinhTrangTanTat> DmTinhTrangTanTat { get; set; }
        public DbSet<DmTinhTrangViecLam> DmTinhTrangViecLam { get; set; }
        public DbSet<DmThoiGianLamViec> DmThoiGianLamViec { get; set; }
        public DbSet<DmTrinhDoHocVan> DmTrinhDoHocVan { get; set; }
        public DbSet<DmTrinhDoNgoaiNgu> DmTrinhDoNgoaiNgu { get; set; }
        public DbSet<DmTrinhDoTinHoc> DmTrinhDoTinHoc { get; set; }
        public DbSet<DmXuatKhauLaoDong> DmXuatKhauLaoDong { get; set; }
        public DbSet<DmTonGiao> DmTonGiao { get; set; }
        public DbSet<DmDanToc> DmDanToc { get; set; }
        public DbSet<DmTrangThaiViecLam> DmTrangThaiViecLam { get; set; }

        //TongHop_PhanTich_DuDoan
        public DbSet<CheDoChinhSach> CheDoChinhSach { get; set; }
        public DbSet<DieuKienLamViec> DieuKienLamViec { get; set; }
        public DbSet<PhuongTienLamViec> PhuongTienLamViec { get; set; }
        public DbSet<RuiRoLamViec> RuiRoLamViec { get; set; }
        public DbSet<TaiNanLaoDong> TaiNanLaoDong { get; set; }
        public DbSet<BanTin> BanTin { get; set; }
        //End TongHop_PhanTich_DuDoan
        //End Manages

        //End Manages

        //Query

    }
}
