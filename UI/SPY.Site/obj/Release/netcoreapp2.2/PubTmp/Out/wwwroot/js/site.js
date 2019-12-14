// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("div.container div.collapse ul li>a").mousedown(function () {
        $("div.container div.collapse ul li>a").css("color", "");
        $(this).css("color", "#f1736a");
    });
    notice();
    var settime = setInterval(notice, 4000);
    $(".SPY-notice-list").hover(function () {
        clearInterval(settime);
    }, function () {
        notice();
        settime = setInterval(notice, 3500);
    })
});
function notice() {
    console.log(parseInt($(".SPY-notice-list").css("top")));
    if (parseInt($(".SPY-notice-list").css("top")) <= -200) {
        $(".SPY-notice-list").css("top", "0px");
    }
    $(".SPY-notice-list").animate({
        top: '-=50px'
    }, 2000);
};
$(function () {
    $(window).scroll(function () {
        console.log($(window).scrollTop);
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
})