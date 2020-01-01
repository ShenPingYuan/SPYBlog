layui.use(['form','layer','table','laytpl'],function(){
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //用户列表
    var tableIns = table.render({
        elem: '#userList',
        url : '/Account/Index',
        cellMinWidth : 95,
        page : true,
        height : "full-125",
        limits : [10,15,20,25],
        limit : 20,
        id : "userListTable",
        cols : [[
            {type: "checkbox", fixed:"left", width:50},
            {field: 'nickName', title: '昵称', minWidth:100, align:"center"},
            {field: 'userName', title: '用户名', minWidth:100, align:"center"},
            {field: 'userEmail', title: '用户邮箱', minWidth:200, align:'center',templet:function(d){
                return '<a class="layui-blue" href="mailto:'+d.userEmail+'">'+d.userEmail+'</a>';
            }
            },
            {
                field: 'userSex', title: '用户性别',width:120, align: 'center', templet: function (d) {
                    if (d.userSex == null) return "就不告诉你";
                    return d.userSex;
                }
            },
            {field: 'userStatus', title: '用户状态',  align:'center',templet:function(d){
                return d.userStatus == true ? "正常使用" : "限制使用";
            }},
            {field: 'userGrade', title: '用户等级', align:'center'},
            {field: 'userEndTime', title: '最后登录时间', align:'center',minWidth:150},
            {title: '操作', minWidth:175, templet:'#userListBar',fixed:"right",align:"center"}
        ]]
    });

    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click",function(){
        if($(".searchVal").val() != ''){
            table.reload("newsListTable",{
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    key: $(".searchVal").val()  //搜索的关键字
                }
            })
        }else{
            layer.msg("请输入搜索的内容");
        }
    });

    //添加用户
    function addUser(edit) {
        var para = "";
        if (typeof (edit) != "undefined") {
            para = "?UserName=" + edit.userName;
        }
        var index = layui.layer.open({
            title : "添加用户",
            type: 2,
            content: "/Account/AddUser" + para,
            success : function(layero, index){
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find(".nickName").val(edit.nickName); 
                    body.find(".userName").val(edit.userName);  //登录名
                    body.find(".userEmail").val(edit.userEmail);  //邮箱
                    body.find(".userSex input[value="+edit.userSex+"]").attr("checked","checked");  //性别
                    body.find(".userGrade").val(edit.userGrade);  //会员等级
                    body.find(".userStatus").val(edit.userStatus);    //用户状态
                    body.find(".userDesc").text(edit.userDesc);    //用户简介
                    form.render();
                }
                setTimeout(function(){
                    layui.layer.tips('点击此处返回用户列表', '.layui-layer-setwin .layui-layer-close', {
                        tips: 3
                    });
                },500)
            }
        })
        layui.layer.full(index);
        window.sessionStorage.setItem("index",index);
        //改变窗口大小时，重置弹窗的宽高，防止超出可视区域（如F12调出debug的操作）
        $(window).on("resize",function(){
            layui.layer.full(window.sessionStorage.getItem("index"));
        })
    }
    $(".addNews_btn").click(function(){
        addUser();
    })
    //列表操作
    table.on('tool(userList)', function(obj){
        var layEvent = obj.event,
            data = obj.data;

        if(layEvent === 'edit'){ //编辑
            addUser(data);
        } else if (layEvent === 'usable') { //启用禁用
            if (data.userName == "2439739932") {
                alert("不能禁用顶级管理员");
                return false;
            }
            var _this = $(this),
                usableText = "是否确定禁用此用户？",
                btnText = "已禁用";
            if(_this.text()=="已禁用"){
                usableText = "是否确定启用此用户？",
                btnText = "已启用";
            }
            layer.confirm(usableText,{
                icon: 3,
                title:'系统提示',
                cancel : function(index){
                    layer.close(index);
                }
            },function(index){
                _this.text(btnText);
                layer.close(index);
            },function(index){
                layer.close(index);
            });
        } else if (layEvent === 'del') { //删除
            if (data.userName == "2439739932") {
                alert("不能删除顶级管理员");
                return false;
            }
            layer.confirm('确定删除此用户？',{icon:3, title:'提示信息'},function(index){
                 //$.get("/Account/DeleteUser",{
                 //    newsId : data.newsId  //将需要删除的newsId作为参数传入
                 //},function(data){
                 //   tableIns.reload();
                 //   layer.close(index);
                // })
                var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
                $.ajax({
                    url: "/Account/DeleteUser",
                    type: "POST",
                    data: {
                        UserName: data.userName
                    },
                    dataType: "text",
                    success: function (res) {
                        tableIns.reload();
                        layer.close(index);
                    }
                })
            });
        }
    });

})