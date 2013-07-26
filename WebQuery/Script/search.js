$(document).ready(function() {
    serarchHandle.scrollMenu();
    serarchHandle.setValue();
    serarchHandle.goTop();
    serarchHandle.searchState();
});

var serarchHandle = {
    search: function() {
        var keyword = $("#txtKeyword");
        var searchTye = $("#searchType").val();
        if (!keyword.val()) {
            keyword.focus();
            return;
        }
        if ($.trim(keyword.val()) == "") {
            keyword.val("");
            keyword.focus();
            return;
        }
        switch (searchTye) {
            case "sell":
                document.location.href = '/search/search-list.aspx?keyword=' + encodeURI(keyword.val());
                break;
            case "buy":
                document.location.href = '/search/buy.aspx?keyword=' + encodeURI(keyword.val());
                break;
            case "company":
                document.location.href = '/search/company.aspx?keyword=' + encodeURI(keyword.val());
                break;
            case "news":
                document.location.href = '/search/news.aspx?keyword=' + encodeURI(keyword.val());
                break;
        }
    },
    setValue: function() {
        var searchType = $("#searchType");
        $("#ul1 li").click(function() {
            $(this).addClass("show");
            $(this).siblings().removeClass("show");
            searchType.val($(this).attr("id"));        //改变隐藏域的值
        });
    },
    scrollMenu: function() {
        $('#mbhelper').hover(
        function() {
            $('.topeOne_show').show();
        },
	   function() {
	       $('.topeOne_show').hide();
	   }
         );
        $('.topeOne_show').hover(
        function() {
            $(this).show();
        },
			function() {
			    $(this).hide();
			}
    );
    },
    //搜索页回到顶部
    goTop: function() {
        if ($(".goTop").length > 0) {
            $(window).scroll(function() {
                var scroll = $(window).scrollTop();
                var top = $(".goTop");
                if (scroll > 0) {
                    top.show();
                }
                else {
                    top.hide();
                }
            });
        }
    },
    //图片大小处理
    DrawImage: function(ImgD, FitWidth, FitHeight) {
        var image = new Image();
        image.src = ImgD.src;
        if (image.width > 0 && image.height > 0) {
            if (image.width / image.height >= FitWidth / FitHeight) {
                if (image.width > FitWidth) {
                    ImgD.width = FitWidth;
                    ImgD.height = (image.height * FitWidth) / image.width;
                } else {
                    ImgD.width = image.width;
                    ImgD.height = image.height;
                }
            } else {
                if (image.height > FitHeight) {
                    ImgD.height = FitHeight;
                    ImgD.width = (image.width * FitHeight) / image.height;
                } else {
                    ImgD.width = image.width;
                    ImgD.height = image.height;
                }
            }
        }
    },
    checkIds: function() {
        var objs = $('input[name=ids]');
        var isChecked = false;
        objs.each(function(o) {
            if ($(this).attr('checked')) {
                isChecked = true;
                return false;
            }
        });
        if (!isChecked) {
            alert('请选择要询价的产品');
            return false;
        }
        return true;
    },
    //设置checkbox属性
    selectId: function(checked) {
        $('input[name=ids]').attr('checked', checked);
        $('input[name=checkId]').attr('checked', checked);
    },
    searchState: function() {
        if ($("#nvaselect").length > 0) {
            var url = $("#nvaselect").val();
            if (url.indexOf("/company.aspx") > -1 || url.indexOf("/member-error.aspx") > -1) {
                $("#ul1 li").removeClass("show");
                $("#company").addClass("show");
                $("#searchType").val("company");
            }
            else if (url.indexOf("/news.aspx") > -1) {
                $("#ul1 li").removeClass("show");
                $("#news").addClass("show");
                $("#searchType").val("news");
            }
            else if (url.indexOf("/buy.aspx") > -1) {
                $("#ul1 li").removeClass("show");
                $("#buy").addClass("show");
                $("#searchType").val("buy");
            }
            else if (url.indexOf('/buy-error.aspx') > -1) {
                $("#ul1 li").removeClass("show");
                $("#buy").addClass("show");
                $("#searchType").val("buy");
            }
        }
    }
}