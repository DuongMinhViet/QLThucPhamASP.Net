var Page = 1;
var numberPage = 7;
$(document).ready(function () {
    ButtonClickEvent();
    //bắt sự kiện click vào pagination
    ListProduct(Page);
    ListCategory();
})
function ButtonClickEvent() {
    $('#PhanTrang').on('click', 'li', function (e) {
        e.preventDefault();
        Page = $(this).text();
        ListProduct(Page);
    })
    $('.btnAdd').click(function () {
        $('.dialog-product input').val(null);
        $('.dialog').show();
        $('.dialog-product').show();
        $('.add-button').show();
        $('.edit-button').hide();
        $('.delete-button').hide();
        $('#txtMaSanPham').focus();
        $('.dialog-product-body input').removeAttr('disabled');
        $('#txtMaDanhMuc').attr('disabled', 'disabled');
    });
    $('.btnEdit').click(function () {
        //Lấy dữ liệu của sách đã chọn tương ứng
        var trSelected = $('#allProduct tr.row-selected');
        if (trSelected.length > 0) {
            //hiện thị form tương ứng
            $('.dialog-product-body input').removeAttr('disabled');
            $('.dialog').show();
            $('.dialog-product').show();
            $('.edit-button').show();
            $('.add-button').hide();
            $('.delete-button').hide();
            $('#txtMaDanhMuc').attr('disabled', 'disabled');
            var MaSanPham = $(trSelected).children()[0].textContent;
            $.ajax({
                url: 'https://localhost:44325/GetProduct/' + MaSanPham,
                method: 'GET'
            }).done(function (response) {
                if (!response) {
                    alert("Không có sản phẩm có mã là: " + MaSanPham);
                }
                else {
                    //binding các thông tin của sản phẩm lên fom
                    $('#txtMaSanPham').val(response.MaSanPham);
                    $('#txtMaSanPham').attr('disabled', 'true');
                    $('#txtMaDanhMuc').val(response.MaDanhMuc);
                    $('#txtTenSanPham').val(response.TenSanPham);
                    $('#txtDonGiaban').val(response.DonGiaban);
                    $('#txtSoLuong').val(response.SoLuong);
                    $('#txtDonViTinh').val(response.DonViTinh);
                    $('#txtAnh').val(response.Anh);
                }
            }).fail(function (response) {

            })
        }
        else {
            alert('Bạn phải chọn sản phẩm cần chỉnh sửa');
        }
    });
    $('.btnDelete').click(function () {
        //Lấy dữ liệu ở hàng tương ứng
        var trSelected = $('#allProduct tr.row-selected');
        if (trSelected.length > 0) {
            $('.dialog').show();
            $('.dialog-product').show();
            $('.edit-button').hide();
            $('.add-button').hide();
            $('.delete-button').show();
            $('#txtMaDanhMuc').attr('disabled', 'disabled');
            var MaSanPham = $(trSelected).children()[0].textContent;
            $.ajax({
                url: 'https://localhost:44325/GetProduct/' + MaSanPham,
                method: 'GET'
            }).done(function (response) {
                if (!response) {
                    alert("Không có sản phẩm có mã là: " + MaSach);
                }
                else {
                    //binding các thông tin của sản phẩm lên fom
                    $('#txtMaSanPham').val(response.MaSanPham);
                    $('#txtMaDanhMuc').val(response.MaDanhMuc);
                    $('#txtTenSanPham').val(response.TenSanPham);
                    $('#txtDonGiaban').val(response.DonGiaban);
                    $('#txtSoLuong').val(response.SoLuong);
                    $('#txtDonViTinh').val(response.DonViTinh);
                    $('#txtAnh').val(response.Anh);
                    $('.dialog-product-body input').attr('disabled', 'true');
                }
            }).fail(function (response) {

            })
        }
        else {
            alert('Bạn phải chọn sản phẩm cần xoá');
        }
    });
    $('.btnCancel').click(function () {
        $('.dialog').hide();
        $('.dialog-product').hide();
    });
    $('.title-close-button').click(function () {
        $('.dialog').hide();
        $('.dialog-product').hide();
    })
}
function ListProduct(Page) {
    var url = 'https://localhost:44325/ListProduct/' + Page;
    $.ajax({
        url: url,
        method: 'GET',
        contentType: 'json',
        dataType: 'json',
        error: function (response) {

        },
        success: function (response) {
            $('allProduct').empty();
            const len = response.length;
            console.log(response);
            let table = '';
            for (var i = 0; i < len; ++i) {
                table = table + '<tr>';
                table = table + '<td>' + response[i].MaSanPham + '</td>';
                table = table + '<td>' + response[i].MaDanhMuc + '</td>';
                table = table + '<td>' + response[i].TenSanPham + '</td>';
                table = table + '<td>' + response[i].DonGiaban + '</td>';
                table = table + '<td>' + response[i].SoLuong + '</td>';
                table = table + '<td>' + response[i].DonViTinh + '</td>';
                table = table + '<td>' + response[i].Anh + '</td>';
                table = table + '</tr>';
            }
            document.getElementById('allProduct').innerHTML = table;
        },
        fail: function (response) { }
    });
    let li = ' ';
    for (i = 1; i <= numberPage; i++) {
        li = li + '<li><a href="#">' + i + '</a></li>'
    }
    document.getElementById('PhanTrang').innerHTML = li;
}
function ListCategory() {
    $.ajax({
        url: 'https://localhost:44325/ListCategory',
        method: 'GET',
        contentType: 'json',
        dataType: 'json',
        error: function (response) {

        },
        success: function (response) {
            const len = response.length;
            console.log(response);
            let ul = '';
            for (var i = 0; i < len; i++) {
                ul = ul + '<li><a>' + response[i].TenDanhMuc + '</a></li>';
            }
            document.getElementById("type-menu").innerHTML = ul;
        },
        fail: function (response) { }
    });
}
function InsertProduct() {
    //Validate dữ liệu
    const number = /^\d+$/;
    var MaSanPham = $('#txtMaSanPham').val();
    var MaDanhMuc = $('#txtMaDanhMuc').val()
    var TenSanPham = $('#txtTenSanPham').val();
    var DonGiaban = $('#txtDonGiaban').val();;
    var SoLuong = $('#txtSoLuong').val();
    var DonViTinh = $('#txtDonViTinh').val()
    var Anh = $('#txtAnh').val()
    if (!MaSanPham) {
        $('#txtMaSanPham').addClass('required-error');
        $('#txtMaSanPham').focus();
        $('#txtMaSanPham').attr("placeholder", "Bạn phải nhập mã sản phẩm");
        return;
    }
    if (!TenSanPham) {
        $('#txtTenSanPham').addClass('required-error');
        $('#txtTenSanPham').focus();
        $('#txtTenSanPham').attr("placeholder", "Bạn phải nhập tên sản phẩm");
        return;
    }
    if (number.test(DonGiaban) == false) {
        $('#txtDonGiaban').addClass('required-error');
        $('#txtDonGiaban').focus();
        $('#txtDonGiaban').attr("title", "Bạn phải nhập đơn giá bán");
        return;
    }
    if (number.test(SoLuong) == false) {
        $('#txtSoLuong').addClass('required-error');
        $('#txtSoLuong').focus();
        $('#txtSoLuong').attr("title", "Bạn phải nhập số lượng");
        return;
    }
    var url = 'https://localhost:44325/api/home?MaSanPham=' + MaSanPham +
        '&MaDanhMuc=' + MaDanhMuc +
        '&TenSanPham=' + TenSanPham +
        '&DonGiaban=' + DonGiaban +
        '&SoLuong=' + SoLuong +
        '&DonViTinh=' + DonViTinh +
        '&Anh=' + Anh;
    $.ajax({
        url: url,
        method: 'POST',
        contentType: 'json',
        dataType: 'json',
        error: function (response) {
            alert("Thêm mới không thành công");
        },
        success: function (reponse) {
            alert("Thêm mới thành công");
            ListProduct(Page);
            $('.dialog').hide();
            $('.dialog-product').hide();
        }
    });
}
function EditProduct() {
    //CHỉnh sửa dữ liệu trên form
    //Validate dữ liệu
    const number = /^\d+$/;
    var MaSanPham = $('#txtMaSanPham').val();
    var MaDanhMuc = $('#txtMaDanhMuc').val()
    var TenSanPham = $('#txtTenSanPham').val();
    var DonGiaban = $('#txtDonGiaban').val();;
    var SoLuong = $('#txtSoLuong').val();
    var DonViTinh = $('#txtDonViTinh').val()
    var Anh = $('#txtAnh').val()
    if (!MaSanPham) {
        $('#txtMaSanPham').addClass('required-error');
        $('#txtMaSanPham').focus();
        $('#txtMaSanPham').attr("placeholder", "Bạn phải nhập mã sản phẩm");
        return;
    }
    if (!TenSanPham) {
        $('#txtTenSanPham').addClass('required-error');
        $('#txtTenSanPham').focus();
        $('#txtTenSanPham').attr("placeholder", "Bạn phải nhập tên sản phẩm");
        return;
    }
    if (number.test(DonGiaban) == false) {
        $('#txtDonGiaban').addClass('required-error');
        $('#txtDonGiaban').focus();
        $('#txtDonGiaban').attr("title", "Bạn phải nhập đơn giá bán");
        return;
    }
    if (number.test(SoLuong) == false) {
        $('#txtSoLuong').addClass('required-error');
        $('#txtSoLuong').focus();
        $('#txtSoLuong').attr("title", "Bạn phải nhập số lượng");
        return;
    }
    //Thực hiện lưu dữ liệu
    var url = 'https://localhost:44325/api/manage?MaSanPham=' + MaSanPham +
        '&MaDanhMuc=' + MaDanhMuc +
        '&TenSanPham=' + TenSanPham +
        '&DonGiaban=' + DonGiaban +
        '&SoLuong=' + SoLuong +
        '&DonViTinh=' + DonViTinh +
        '&Anh=' + Anh;
    $.ajax({
        url: url,
        method: 'PUT',
        contentType: 'json',
        dataType: 'json',
        error: function (response) {
            alert("Sửa thông tin sản phẩm không thành công");
        },
        success: function (response) {
            alert("Sửa thông tin sản phẩm thành công");
            ListProduct(Page);
            $('.dialog').hide();
            $('.dialog-product').hide();
        }
    });
}
function DeleteProduct() {
    //Lấy ra mã sách đang được chọn
    var MaSanPham = $('#txtMaSanPham').val();
    var url = 'https://localhost:44325/DeleteProduct/' + MaSanPham;
    $.ajax({
        url: url,
        method: 'DELETE',
        contentType: 'json',
        dataType: 'json',
        success: function (response) {
            alert("Xoá thông tin sản phẩm thành công");
            ListProduct(Page);
            $('.dialog').hide();
            $('.dialog-product').hide();
        },
        error: function () {
            alert("Xoá thông tin sản phẩm không thành công");
        }
    });
}
$(document).on('click', '#allProduct tr', function () {
    $(this).siblings().removeClass('row-selected');
    $(this).addClass('row-selected');
})
$('html').click(function () {
    $('#allProduct tr').siblings().removeClass('row-selected');
})
