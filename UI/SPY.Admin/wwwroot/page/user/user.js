layui.use(['form', 'layer', 'laydate', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laydate = layui.laydate,
        laytpl = layui.laytpl,
        table = layui.table;

    var pwdVerifyResult = "";
    function ajaxVerify(data) {
        $.ajax({
            url: "/Account/LoginApi",
            type: "POST",
            async: "false",
            data: {
                UserName: $(".userName").val(),
                Password: $(".oldPassword").val(),
            },
            dataType: "json",
            success: function (res) {
                pwdVerifyResult = res;
            }
        });
    }
    ajaxVerify();
    //按键弹起，后台验证密码
    $("input.oldPassword").keyup(function (e) {
        if ($(e.target).val().length >= 6) {
            ajaxVerify();
        }
    });
    //添加验证规则
    form.verify({
        oldPwd: function (value, item) {
            if (pwdVerifyResult == "失败") {
                return "密码错误，请重新输入！";
            } else if (pwdVerifyResult == "用户不存在") {
                return "用户不存在";
            }
        },
        newPwd: function (value, item) {
            if (value.length < 6) {
                return "密码长度不能小于6位";
            }
        },
        confirmPwd: function (value, item) {
            if (!new RegExp($("#oldPwd").val()).test(value)) {
                return "两次输入密码不一致，请重新输入！";
            }
        }
    })
    //修改密码
    form.on("submit(changePwd)", function (data) {
        var index = top.layer.msg('提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        $.ajax({
            url: "/Account/ChangePwd",
            type: "POST",
            data: {
                UserName: data.field.userName,
                OldPassword: data.field.oldPassword,
                NewPassword: data.field.newPassword
            },
            dataType: "json",
            success: function (res) {
                top.layer.close(index);
                if (res == "SUCCEED") {
                    top.layer.msg("修改成功！");
                } else {
                    top.layer.msg("修改失败！");
                }
                layer.closeAll("iframe");
                //刷新父页面
                parent.location.reload();
            }
        });
        return false;
    });
        //用户等级
    var tableRoles = table.render({
        elem: '#userGrade',
        url: '/Role/Index',
        async: true,
        cellMinWidth: 95,
        cols: [[
            { field: "rowId", title: 'ID', width: 60, fixed: "left", sort: "true", align: 'center', edit: 'text' },
            { field: "roleId", title: '等级', minWidth: 100, fixed: "left", sort: "false", align: "center" },
            { field: 'gradeIcon', title: '图标展示', templet: '#gradeIcon', align: 'center' },
            { field: 'roleName', title: '等级名称', edit: 'text', align: 'center' },
            //{field: 'gradeValue', title: '等级值', edit: 'text',sort:"true", align:'center'},
            //{field: 'gradeGold', title: '默认金币', edit: 'text',sort:"true", align:'center'},
            //{field: 'gradePoint', title: '默认积分', edit: 'text',sort:"true", align:'center'},
            { title: '当前状态', minWidth: 100, templet: '#gradeBar', fixed: "right", align: "center" },
            { title: '操作', minWidth: 175, templet: '#roleOperateBar', fixed: "right", align: "center" }
        ]]
    });
    form.on('switch(gradeStatus)', function (data) {
        var tipText = '确定禁用当前会员等级？';
        if (data.elem.checked) {
            tipText = '确定启用当前会员等级？'
        }
        layer.confirm(tipText, {
            icon: 3,
            title: '系统提示',
            cancel: function (index) {
                data.elem.checked = !data.elem.checked;
                form.render();
                layer.close(index);
            }
        }, function (index) {
            layer.close(index);
        }, function (index) {
            data.elem.checked = !data.elem.checked;
            form.render();
            layer.close(index);
        });
    });

    table.on('tool(userGrade)', function (obj) {
        var layEvent = obj.event,
            listdata = obj.data;
        //删除角色
        if (layEvent === 'del') { //删除
            layer.confirm('确定删除此用户？', { icon: 3, title: '提示信息' }, function (index) {
                //$.get("删除文章接口",{
                //    newsId : data.newsId  //将需要删除的newsId作为参数传入
                //},function(data){
                var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });

                $.ajax({
                    url: "/Role/RoleDelete",
                    type: "POST",
                    data: {
                        roleId: listdata.roleId,
                        roleName: listdata.roleName
                    },
                    dataType: "text",
                    success: function (res) {
                        if (res == "删除失败!") {
                            tableIns.reload();
                            layer.close(index);
                            return false;
                        }
                        tableRoles.reload();
                        layer.close(index);
                    }
                })
            });
        }

    });
    //新增等级
    $(".addRole").click(function () {
        //$.ajax({
        //    url: "/Role/AddRole",
        //    type: "POST",
        //    data: JSON.stringify({
        //        RoleName:
        //    })
        //})
        addRole();
        //var $tr = $(".layui-table-body.layui-table-main tbody tr:last");
        //if ($tr.data("index") > 9) {
        //    layer.alert("模版中由于图标数量的原因，只支持到vip10，实际开发中可根据实际情况修改。当然也不要忘记增加对应等级的颜色。", { maxWidth: 300 });
        //} else {
        //    var index;
        //    if (isNaN($tr.data("index"))) {
        //        index = 0;
        //    } else {
        //        index = $tr.data("index");
        //    }
        //    var newHtml = '<tr data-index="' + (index + 1) + '">' +
        //        '<td data-field="id" data-edit="text" align="center"><div class="layui-table-cell laytable-cell-1-id">' + (index + 1) + '</div></td>' +
        //        '<td data-field="gradeIcon" align="center" data-content="icon-vip' + (index + 1) + '"><div class="layui-table-cell laytable-cell-1-gradeIcon"><span class="seraph vip' + (index + 1) + ' icon-vip' + (index + 1) + '"></span></div></td>' +
        //        '<td data-field="gradeName" data-edit="text" align="center"><div class="layui-table-cell laytable-cell-1-gradeName">请输入等级名称</div></td>' +
        //        '<td data-field="gradeValue" data-edit="text" align="center"><div class="layui-table-cell laytable-cell-1-gradeValue">0</div></td>' +
        //        '<td data-field="gradeGold" data-edit="text" align="center"><div class="layui-table-cell laytable-cell-1-gradeGold">0</div></td>' +
        //        '<td data-field="gradePoint" data-edit="text" align="center"><div class="layui-table-cell laytable-cell-1-gradePoint">0</div></td>' +
        //        '<td data-field="' + (index + 1) + '" align="center" data-content="" data-minwidth="100"><div class="layui-table-cell laytable-cell-1-' + (index + 1) + '"> <input type="checkbox" name="gradeStatus" lay-filter="gradeStatus" lay-skin="switch" lay-text="启用|禁用" checked=""><div class="layui-unselect layui-form-switch layui-form-onswitch" lay-skin="_switch"><em>启用</em><i></i></div></div></td>' +
        //        '</tr>';
        //    $(".layui-table-body.layui-table-main tbody").append(newHtml);
        //    $(".layui-table-fixed.layui-table-fixed-l tbody").append('<tr data-index="' + (index + 1) + '"><td data-field="id" data-edit="text" align="center"><div class="layui-table-cell laytable-cell-1-id">' + (index + 1) + '</div></td></tr>');
        //    $(".layui-table-fixed.layui-table-fixed-r tbody").append('<tr data-index="' + (index + 1) + '"><td data-field="' + (index + 1) + '" align="center" data-content="" data-minwidth="100"><div class="layui-table-cell laytable-cell-1-' + (index + 1) + '"> <input type="checkbox" name="gradeStatus" lay-filter="gradeStatus" lay-skin="switch" lay-text="启用|禁用" checked=""><div class="layui-unselect layui-form-switch layui-form-onswitch" lay-skin="_switch"><em>启用</em><i></i></div></div></td></tr>');
        //    form.render();
        //}
    });

    //控制表格编辑时文本的位置【跟随渲染时的位置】
    $("body").on("click", ".layui-table-body.layui-table-main tbody tr td", function () {
        $(this).find(".layui-table-edit").addClass("layui-" + $(this).attr("align"));
    });
    //添加角色
    function addRole(edit) {
        var index = layui.layer.open({
            title: "添加角色",
            type: 2,
            content: "roleAdd.html",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    form.render();
                }
                setTimeout(function () {
                    layui.layer.tips('点击此处返回用户列表', '.layui-layer-setwin .layui-layer-close', {
                        tips: 3
                    });
                }, 500)
            }
        })
        layui.layer.full(index);
        window.sessionStorage.setItem("index", index);
        //改变窗口大小时，重置弹窗的宽高，防止超出可视区域（如F12调出debug的操作）
        $(window).on("resize", function () {
            layui.layer.full(window.sessionStorage.getItem("index"));
        })
    }
})