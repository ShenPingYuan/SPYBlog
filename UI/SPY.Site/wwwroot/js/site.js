
//import { setTimeout } from "timers";

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $.ajax({
        url: "/Content/NewsList",
        type: "GET",
        success: function (res) {
            if (res.msg == "SUCCESS") {
                for (var i = 0; i < res.count; i++) {
                    var html = '<li><a href="' + res.data[i].newsUrl + '">' + res.data[i].newsName + '</a></li>';
                    $(".SPY-notice-list").append(html);
                }
                noticeRun();
            }
        }
    });
})
function noticeRun() {
    $("div.container div.collapse ul li>a").mousedown(function () {
        $("div.container div.collapse ul li>a").css("color", "");
        $(this).css("color", "#f1736a");
    });
    notice();
    var settime = setInterval(notice, 3500);
    $(".SPY-notice-list").hover(function () {
        clearInterval(settime);
    }, function () {
        notice();
        settime = setInterval(notice, 3500);
    })
};
function notice() {
    //console.log(parseInt($(".SPY-notice-list").css("top")));
    console.log($("ul.SPY-notice-list li").length);
    if (parseInt($(".SPY-notice-list").css("top")) <= -(($("ul.SPY-notice-list li").length)-1)*50) {
        $(".SPY-notice-list").css("top", "0px");
    }
    $(".SPY-notice-list").animate({
        top: '-=50px'
    }, 2000);
};
$(function () {
    $(window).scroll(function () {
        if ($("html,body").scrollTop() < 30) {
            $(".ReturnToTop").fadeOut(500);
        } else {
            $(".ReturnToTop").fadeIn(500);
        }
    });
    $(".ReturnToTop").click(function () {
        $("html,body").animate({ scrollTop: 0 }, 300);
    })
});
$(function () {
    $(".SPY-software-items").each(function () {
        $(this).children(".content").css("height", (parseInt($(this).children(".content").children("a").css("height")) + 20).toString() + "px");
    })
});
$(function () {
    $(".Comment #qq").keyup(function () {
        if ($("#qq").val().length == 0) {
            $(".Comment .Comment-form .user-info-head ").attr("src", "/images/user-default.png");
        } else {
            $(".Comment .Comment-form .user-info-head ").attr("src", "http://q1.qlogo.cn/g?b=qq&nk=" + $("#qq").val() + "&s=100");
            $.ajax({
                url: "/Content/GetUserInfo",
                type: "GET",
                data: {
                    qq: $("#qq").val()
                },
                success: function (res) {
                    $(".Comment-user .user-info-details input[name='nickname']").val(res);
                }
            })
        }
    });
    //https://users.qzone.qq.com/fcg-bin/cgi_get_portrait.fcg?uins=2439739932
    var valiResult = $(".Comment-form").validate({
        rules: {
            qq: {
                required: true,
            },
            nickname: {
                required: true,
            },
            content: {
                required: true,
            }
        },
        messages: {
            nickname: {
                required: "请输入昵称",
            },
            qq: {
                required: "请输入QQ号",
            },
            content: {
                required: "请输入评论内容",
            }
        },
        errorElement: "label",
        success: function (label) { //验证成功后的执行的回调函数
            //label指向上面那个错误提示信息标签label
            //label.text(" ") //清空错误提示消息
            //    .addClass("success"); //加上自定义的success类
            label.text("");

        }
    });
    $(".Comment-submit-btn").click(function () {
        if (valiResult.form()) {
            var html = "<li><div class='Comment-body'>" +
                "<div class='comment-user-image'>" +
                "<img class='user-info-head' src=" + $(".user-info-head").attr("src") + "></div><div class='comment-user-info'>" +
                "<div class='Comment-top'>" +
                "<span class='user-nickname' >" + $("#nickname").val() + "</span >" +
                "<span class='Comment-time' style='color: #757575;'>" + new Date().toLocaleString() + "</span></div>" +
                "<div class='Comment-content'>" +
                "<div class='Comment-content-text'>" +
                $("#comment-textarea").val() +
                "</div>" +
                "</div>" +
                "<div class='Comment-footer'>" +
                "<span class='reply' style='color: #a5a5f9;'>回复</span>" +
                "<span class='support'>" +
                "<span>赞</span>" +
                0
            "</span>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</li >";
            $(".Comment-ul").append(html);

            $.ajax({
                url: "/Comment/AddComment",
                type: "POST",
                data: {
                    HeadImageUrl: $(".user-info-head").attr("src"),
                    QQ: $("#qq").val(),
                    NickName: $("#nickname").val(),
                    CommentTime: new Date().toLocaleString(),
                    Content: $("#comment-textarea").val(),
                    ArticleId: $("#articleId").val(),
                },
                dataType: "json",
                success: function (res) {
                },
                error: function (res) {
                    alert("失败");
                }
            });
        }
    })
});
$(function () {
    $.ajax({
        url: "/api/Tag",
        type: "GET",
        cache: false,
        dataType: "json",
        success: function (res) {
            if (res.code == 0) {
                for (var i = 0; i < res.count; i++) {
                    var html = '<a target="_blank" href="' + res.data[i].src + '" class="btn btn-success">' + res.data[i].name + '</a>&nbsp;';
                    if (res.data[i].isInChina == "国内") {
                        $(".InChina").append(html);
                    } else {
                        $(".NotInChina").append(html);
                    }
                }
            }
        }
    });
    $.ajax({
        url: "/api/siteinfo",
        type: "PUT",
        async: true,
        cache: false,
        dataType: "json",
        success: function (res) {
        }
    });
    $.ajax({
        url: "/api/siteinfo",
        type: "GET",
        cache: false,
        dataType: "json",
        success: function (res) {
            if (res.code == 0) {
                $("#articleCount").text(res.data.articleCount);
                $("#tagCount").text(res.data.tagCount);
                $("#columnCount").text(res.data.columnCount);
                $("#commentCount").text(res.data.commentCount);
                $("#views").text(res.data.views);
                if (res.data.centerTitle != null) {
                    $("#centerTitle").text(res.data.centerTitle);
                }
                if (res.data.motto != null) {
                    $("#motto").text(res.data.motto);
                }
            }
        }
    });
})
//主页大图文章，完成
function LoadArticleListPage(pageIndex) {
    var htmlloading = '<div class="loading"><img src="/images/loading.gif" alt = "Alternate Text" /></div>';
    $.ajax({
        url: "/ContentList/BigArticleList?pageIndex=" + pageIndex,
        type: "GET",
        cache: false,
        dataType: "json",
        beforeSend: function () {
            $(".SPY-article").append(htmlloading);
        },
        success: function (res) {
            if (res.code == 0) {
                $(".SPY-article .loading").remove();
                if (res.count == 0) {
                    tag = false;
                }
                for (var i = 0; i < res.count; i++) {
                    var userFaceImg = "http://q1.qlogo.cn/g?b=qq&nk=2439739932&s=100";
                    if (res.data[i].userFaceImgUrl != null) {
                        userFaceImg = res.data[i].userFaceImgUrl;
                    }
                    var html = '<div class="SPY-article-items">' +
                                    '<div class="SPY-article-items-content">' +
                                    '<div class="content-author">' +
                        '<img src="' + userFaceImg + '" alt="">&nbsp;' +
                                    '<div class="author-details">' +
                                    '<span class="author-name">SPY顶级管理员</span>' +
                                    '<p class="article-time">' + res.data[i].addTime + '</p> ' +
                                    '</div>' +
                                    '</div>' +
                                    '<div class="content-title">' +
                                    '<span class="label label-success">置顶</span>&nbsp;' +
                                    '<span class="label label-danger"><a href="/Content/ArticleContent?id=' + res.data[i].id + '" style="color: white;text-decoration: none">#点击进入#</a></span>&nbsp;' +
                                    '<a href="/Content/ArticleContent?id=' + res.data[i].id + '">' + res.data[i].title + '</a>' +
                                    '</div>' +
                                    '<div class="content-img">' +
                                    '<p>' + res.data[i].description + '</p>' +
                                    '<a href="/Content/ArticleContent?id=' + res.data[i].id + '">' +
                                    '<img src="' + res.data[i].imageUrl + '" alt="">' +
                                    '</a>' +
                                    '</div>' +
                                    '<div class="content-footer">' +
                                    '<svg t="1573320606457" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="3050" width="16" height="16"><path d="M512.752 948.368C306.24 948.368 160 803.632 160 604.352c0-105.872 62.72-219.92 65.472-224.592a27.744 27.744 0 0 1 27.424-13.968c11.12 1.472 20 9.584 23.072 20.336 0.208 0.592 17.168 64.704 39.424 100.192 14.928 23.952 30.208 40.752 47.36 52.544-11.616-50.72-20.432-127.12-6.016-205.344 39.36-214.832 206.752-266.384 213.904-268.48a27.488 27.488 0 0 1 34.4 31.904c-0.16 1.472-27.92 152.032 30.672 280.32 5.344 11.68 12.72 25.12 20.704 38.784a364.8 364.8 0 0 1 11.36-57.632c21.6-76.048 77.184-102.064 79.584-103.056a27.344 27.344 0 0 1 28.08 3.456 27.68 27.68 0 0 1 10.064 26.832c-0.304 1.92-8.112 53.728 35.6 127.12 39.456 66.256 50.704 109.232 50.704 191.76-0.192 199.2-150.976 343.84-359.056 343.84zM247.888 474.64a352.272 352.272 0 0 0-24.288 127.136c0 162.272 119.616 280 289.264 280 170.976 0 295.04-117.728 295.04-280.048 0-70.16-8.592-102.544-41.712-158.368-22.112-37.216-33.168-70.672-38.176-97.392a124.656 124.656 0 0 0-13.712 31.808c-16.16 57.12-12 124.16-12 124.912a27.008 27.008 0 0 1-17.696 27.008c-11.184 4.048-23.68 0.032-30.432-9.76-2.096-2.8-49.232-70.4-70.016-116.08-43.104-94.368-42.528-196.544-38.176-255.36-43.696 25.728-110.944 83.312-132.64 200.352-21.008 114.048 19.808 233.248 20.224 234.352a27.152 27.152 0 0 1-4.832 27.408 26.16 26.16 0 0 1-26.16 8.4c-3.248-0.8-83.424-20.448-131.744-97.6a325.696 325.696 0 0 1-22.944-46.768z" fill="#000000" p-id="3051"></path></svg>' +
                                    '&nbsp;<span>' + res.data[i].viewCount + '</span>&nbsp;' +
                                    '<svg t="1573320543040" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="2239" width="16" height="16"><path d="M834.37778 716.13833l-85.74999 0c-11.879562 0-21.505803-9.657964-21.505803-21.441335 0-11.879562 9.625218-21.537526 21.505803-21.537526l85.74999 0c23.663956 0 42.97886-19.266809 42.97886-42.97886l0-429.788603c0-23.712051-19.314904-42.97886-42.97886-42.97886l-644.682905 0c-23.712051 0-42.97886 19.266809-42.97886 42.97886l0 429.788603c0 23.712051 19.266809 42.97886 42.97886 42.97886l365.224122 0c5.692652 0 11.17655 2.318812 15.173584 6.299473l193.46934 193.404871c8.394181 8.425903 8.394181 22.032806 0 30.379914-4.14132 4.204765-9.673313 6.347568-15.141862 6.347568-5.516644 0-11.048637-2.142803-15.189957-6.347568L546.029536 716.13833 189.694875 716.13833c-47.455825 0-86.005816-38.533618-86.005816-85.957721l0-429.788603c0-47.376007 38.549991-85.957721 86.005816-85.957721l644.682905 0c47.424102 0 85.957721 38.581714 85.957721 85.957721l0 429.788603C920.335501 677.604712 881.801882 716.13833 834.37778 716.13833L834.37778 716.13833zM318.631456 458.265168c-23.760147 0-42.97886-19.218714-42.97886-42.97886s19.218714-42.97886 42.97886-42.97886c23.712051 0 42.97886 19.218714 42.97886 42.97886S342.343507 458.265168 318.631456 458.265168L318.631456 458.265168zM512.004605 458.265168c-23.743774 0-42.97886-19.218714-42.97886-42.97886s19.235087-42.97886 42.97886-42.97886c23.760147 0 42.97886 19.218714 42.97886 42.97886S535.763728 458.265168 512.004605 458.265168L512.004605 458.265168zM705.441199 458.265168c-23.760147 0-42.97886-19.218714-42.97886-42.97886s19.218714-42.97886 42.97886-42.97886c23.712051 0 42.97886 19.218714 42.97886 42.97886S729.15325 458.265168 705.441199 458.265168L705.441199 458.265168z" p-id="2240"></path></svg>' +
                                    '&nbsp;<span>' + res.data[i].commentCount + '</span>&nbsp;' +
                                    '</div>' +
                                    '</div>' +
                                    '</div>';
                    $(".SPY-article").append(html);
                }

            }
        },
    });
}
$(function () {
    var pageIndex = 1;
    LoadArticleListPage(pageIndex);
    pageIndex++;
    var controller = 1;
    var tag = true;
    $(window).scroll(function () {
        if ($(document).scrollTop() >= $(document).height() - $(window).height()) {
            if (controller == 1 && tag) {
                controller = 0;

                var htmlloading = '<div class="loading"><img src="/images/loading.gif" alt = "Alternate Text" /></div>';
                $.ajax({
                    url: "/ContentList/BigArticleList?pageIndex=" + pageIndex,
                    type: "GET",
                    cache: false,
                    dataType: "json",
                    //async: false,
                    beforeSend: function () {
                        $(".SPY-article .loading").remove();
                        $(".SPY-article").append(htmlloading);
                    },
                    success: function (res) {
                        if (res.code == 0) {
                            setTimeout($(".SPY-article .loading").remove(), 4000);
                            if (res.count == 0) {
                                tag = false;
                                $(".SPY-article").append('<div class="NoData"><span>无更多数据</span></div>');
                                return false;
                            }
                            for (var i = 0; i < res.count; i++) {
                                var userFaceImg = "http://q1.qlogo.cn/g?b=qq&nk=2439739932&s=100";
                                if (res.data[i].userFaceImgUrl != null) {
                                    userFaceImg = res.data[i].userFaceImgUrl;
                                }
                                var html = '<div class="SPY-article-items">' +
                                    '<div class="SPY-article-items-content">' +
                                    '<div class="content-author">' +
                                    '<img src="' + userFaceImg + '" alt="">&nbsp;' +
                                    '<div class="author-details">' +
                                    '<span class="author-name">SPY顶级管理员</span>' +
                                    '<p class="article-time">' + res.data[i].addTime + '</p> ' +
                                    '</div>' +
                                    '</div>' +
                                    '<div class="content-title">' +
                                    '<span class="label label-success">置顶</span>&nbsp;' +
                                    '<span class="label label-danger"><a href="/Content/ArticleContent?id=' + res.data[i].id + '" style="color: white;text-decoration: none">#点击进入#</a></span>&nbsp;' +
                                    '<a href="/Content/ArticleContent?id=' + res.data[i].id + '">' + res.data[i].title + '</a>' +
                                    '</div>' +
                                    '<div class="content-img">' +
                                    '<p>' + res.data[i].description + '</p>' +
                                    '<a href="/Content/ArticleContent?id=' + res.data[i].id + '">' +
                                    '<img src="' + res.data[i].imageUrl + '" alt="">' +
                                    '</a>' +
                                    '</div>' +
                                    '<div class="content-footer">' +
                                    '<svg t="1573320606457" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="3050" width="16" height="16"><path d="M512.752 948.368C306.24 948.368 160 803.632 160 604.352c0-105.872 62.72-219.92 65.472-224.592a27.744 27.744 0 0 1 27.424-13.968c11.12 1.472 20 9.584 23.072 20.336 0.208 0.592 17.168 64.704 39.424 100.192 14.928 23.952 30.208 40.752 47.36 52.544-11.616-50.72-20.432-127.12-6.016-205.344 39.36-214.832 206.752-266.384 213.904-268.48a27.488 27.488 0 0 1 34.4 31.904c-0.16 1.472-27.92 152.032 30.672 280.32 5.344 11.68 12.72 25.12 20.704 38.784a364.8 364.8 0 0 1 11.36-57.632c21.6-76.048 77.184-102.064 79.584-103.056a27.344 27.344 0 0 1 28.08 3.456 27.68 27.68 0 0 1 10.064 26.832c-0.304 1.92-8.112 53.728 35.6 127.12 39.456 66.256 50.704 109.232 50.704 191.76-0.192 199.2-150.976 343.84-359.056 343.84zM247.888 474.64a352.272 352.272 0 0 0-24.288 127.136c0 162.272 119.616 280 289.264 280 170.976 0 295.04-117.728 295.04-280.048 0-70.16-8.592-102.544-41.712-158.368-22.112-37.216-33.168-70.672-38.176-97.392a124.656 124.656 0 0 0-13.712 31.808c-16.16 57.12-12 124.16-12 124.912a27.008 27.008 0 0 1-17.696 27.008c-11.184 4.048-23.68 0.032-30.432-9.76-2.096-2.8-49.232-70.4-70.016-116.08-43.104-94.368-42.528-196.544-38.176-255.36-43.696 25.728-110.944 83.312-132.64 200.352-21.008 114.048 19.808 233.248 20.224 234.352a27.152 27.152 0 0 1-4.832 27.408 26.16 26.16 0 0 1-26.16 8.4c-3.248-0.8-83.424-20.448-131.744-97.6a325.696 325.696 0 0 1-22.944-46.768z" fill="#000000" p-id="3051"></path></svg>' +
                                    '&nbsp;<span>' + res.data[i].viewCount + '</span>&nbsp;' +
                                    '<svg t="1573320543040" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="2239" width="16" height="16"><path d="M834.37778 716.13833l-85.74999 0c-11.879562 0-21.505803-9.657964-21.505803-21.441335 0-11.879562 9.625218-21.537526 21.505803-21.537526l85.74999 0c23.663956 0 42.97886-19.266809 42.97886-42.97886l0-429.788603c0-23.712051-19.314904-42.97886-42.97886-42.97886l-644.682905 0c-23.712051 0-42.97886 19.266809-42.97886 42.97886l0 429.788603c0 23.712051 19.266809 42.97886 42.97886 42.97886l365.224122 0c5.692652 0 11.17655 2.318812 15.173584 6.299473l193.46934 193.404871c8.394181 8.425903 8.394181 22.032806 0 30.379914-4.14132 4.204765-9.673313 6.347568-15.141862 6.347568-5.516644 0-11.048637-2.142803-15.189957-6.347568L546.029536 716.13833 189.694875 716.13833c-47.455825 0-86.005816-38.533618-86.005816-85.957721l0-429.788603c0-47.376007 38.549991-85.957721 86.005816-85.957721l644.682905 0c47.424102 0 85.957721 38.581714 85.957721 85.957721l0 429.788603C920.335501 677.604712 881.801882 716.13833 834.37778 716.13833L834.37778 716.13833zM318.631456 458.265168c-23.760147 0-42.97886-19.218714-42.97886-42.97886s19.218714-42.97886 42.97886-42.97886c23.712051 0 42.97886 19.218714 42.97886 42.97886S342.343507 458.265168 318.631456 458.265168L318.631456 458.265168zM512.004605 458.265168c-23.743774 0-42.97886-19.218714-42.97886-42.97886s19.235087-42.97886 42.97886-42.97886c23.760147 0 42.97886 19.218714 42.97886 42.97886S535.763728 458.265168 512.004605 458.265168L512.004605 458.265168zM705.441199 458.265168c-23.760147 0-42.97886-19.218714-42.97886-42.97886s19.218714-42.97886 42.97886-42.97886c23.712051 0 42.97886 19.218714 42.97886 42.97886S729.15325 458.265168 705.441199 458.265168L705.441199 458.265168z" p-id="2240"></path></svg>' +
                                    '&nbsp;<span>' + res.data[i].commentCount + '</span>&nbsp;' +
                                    '</div>' +
                                    '</div>' +
                                    '</div>';
                                $(".SPY-article").append(html);
                            }
                            pageIndex++
                            controller = 1;
                        }
                    }
                });
            }
        }
    });
});

$(function () {
    $.ajax({
        url: "/ContentList/LastestArticle?topCount=5",
        type: "GET",
        cache: false,
        dataType: "json",
        success: function (res) {
            if (res.code == 0) {
                for (var i = 0; i < res.count; i++) {
                    var articleImg = "http://q1.qlogo.cn/g?b=qq&nk=2439739932&s=100";
                    if (res.data[i].userFaceImgUrl != null) {
                        articleImg = res.data[i].imageUrl;
                    }
                    var html = '<div class="SPY-content-items">' +
                        '<img src="' + articleImg + '" alt="">&nbsp;' +
                                        '<div class="SPY-items-details">' +
                        '<a href="/Content/ArticleContent?id=' + res.data[i].id + '" class="SPY-items-title">#' + res.data[i].title + '</a>' +
                                        '<p class="SPY-items-desc">' + res.data[i].viewCount + '次围观</p>' +
                                    '</div>' +
                                '</div>';
                    $(".SPY-mainContent-right-two .SPY-content").append(html);
                }
            }
        }
    });
    $.ajax({
        url: "/ContentList/HotArticle?topCount=10",
        type: "GET",
        cache: false,
        dataType: "json",
        success: function (res) {
            if (res.code == 0) {
                for (var i = 0; i < res.count; i++) {
                    var articleImg = "http://q1.qlogo.cn/g?b=qq&nk=2439739932&s=100";
                    if (res.data[i].userFaceImgUrl != null) {
                        articleImg = res.data[i].imageUrl;
                    }
                    var html = '<div class="SPY-content-items">' +
                        '<img src="' + articleImg + '" alt="">&nbsp;' +
                        '<div class="SPY-items-details">' +
                        '<a href="/Content/ArticleContent?id=' + res.data[i].id + '" class="SPY-items-title">#' + res.data[i].title + '</a>' +
                        '<p class="SPY-items-desc">' + res.data[i].viewCount + '次围观</p>' +
                        '</div>' +
                        '</div>';
                    $(".SPY-mainContent-right-one .SPY-content").append(html);
                }
            }
        }
    });
})
$(function () {
    $.ajax({
        url: "/ContentList/LifeCircle?topCount=6&category=私人空间",
        type: "GET",
        dataType: "json",
        cache: false,
        success: function (res) {
            if (res.code == 0) {
                for (var i = 0; i < res.count; i++) {
                    var html = '<li>' +
                        //'<input type="hidden" name="" id="lifecircle' + i + '" value=' + res.data[i].articleId + ' />' +
                        '<a href="/Content/ArticleContent?id=' + res.data[i].articleId + '">' +
                        '<img src="' + res.data[i].imageUrl + '" alt="">' +
                        '</a>' +
                        '</li>';
                    $(".SPY-life-circle>ul").append(html);
                }
            }
        }
    });
    $.ajax({
        url: "/Comment/CommentList?topCount=9",
        type: "GET",
        dataType: "json",
        cache: false,
        success: function (res) {
            if (res.code == 0) {
                for (var i = 0; i < res.count; i++) {
                    var html = '<li>' +
                        //'<input type="hidden" name="" id="lifecircle' + i + '" value=' + res.data[i].articleId + ' />' +
                        '<a href="/Content/ArticleContent?id=' + res.data[i].articleId + '">' +
                        '<img src="' + res.data[i].headImageUrl + '" alt="">' +
                        '</a>' +
                        '</li>';
                    $(".SPY-latest-comment>ul").append(html);
                }
            }
        }
    })
})
$(function () {
    $(".btn-search").click(function () {
        if ($("input[name='keyWords']").val() == "") {
            alert("未输入内容,请输入搜索内容");
            return false;
        }
        //$.ajax({
        //    url: "/ContentList/ArticleSearch?keyWords=" + $("input[name='search']").val(),
        //    type: "GET",
        //    dataType: "json",
        //});
    })
    
})
$(function () {
    $("div.article-support span.support").click(function () {
        var currentCount = parseInt($("div.article-support span.support>span").text());
        $("div.article-support span.support>span").text((currentCount + 1).toString());
        $.ajax({
            url: "/Content/SupportClick",
            type: "PUT",
            data: {
                ArticleId: $("input[name='articleId']").val(),
            },
        })
    });
});
$(function () {
    $("div.Comment-footer span.support").click(function () {
        var currentCount = parseInt($(this).children("span.support span:nth-child(2)").text());
        $(this).children("span.support span:nth-child(2)").text((currentCount + 1).toString());
        $.ajax({
            url: "/Comment/SupportClick",
            type: "PUT",
            data: {
                CommentId: $(this).parents("li").children("form").children("input[name='commentId']").val(),
            },
        })
    });
})
