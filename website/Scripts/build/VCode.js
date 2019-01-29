(function ($) {
    $.fn.VCode = function (options) {
        // 初始化声明
        var defaults = {
            frontimg: "",// 切块图
            backimg: "",// 背景图
        };

        // 外部div
        var opts = $.extend(defaults, options);
        // 模态框
        var $this = $(this);//获取当前对象
        var html = '<div class="modal fade" id="VCodeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">' +
            '<div class="modal-dialog" style="width:330px;">' +
            '<div class="modal-content">' +
            '<div class="vCode_model">' +
            '<div class="vCode_img_bg">' +
            "<img src='' class='vCode_img' />" +
            '<div class="vCode_push_bg">' +
            "<i class='vCode_push vCode_push_img'> 刷新</i>" +
            '<span class="vCode_push_span">验证码过期,请刷新</span>' +
            '</div>' +
            '</div >' +
            // 滑动条
            '<div>' +
            '<div class="vCode_select_bg">' +
            '<div class="vCode_select_but"></div>' +
            '<span class="vCode_select_span">按住滑块,拖动完成拼图</span>' +
            '</div></div ></div ></div ></div ></div >';
        this.append(html);

        //定义拖动参数
        var $divMove = $this.find(".vCode_select_but"); //拖动按钮
        var $divWrap = $this.find(".vCode_select_bg");//鼠标可拖拽区域
        var mX = 0, mY = 0;//定义鼠标X轴Y轴
        var dX = 0, dY = 0;//定义滑动区域左、上位置
        var isDown = false;//mousedown标记
        //if (document.attachEvent) {//ie的事件监听，拖拽div时禁止选中内容，firefox与chrome已在css中设置过-moz-user-select: none; -webkit-user-select: none;
        //    $divMove[0].attachEvent('onselectstart', function () {
        //        return false;
        //    });
        //}

        //点击滑动按钮事件
        $divMove.unbind('mousedown').on({
            mousedown: function (e) {
                //清除提示信息
                $this.find(".vCode_push_span").html("");
                var event = e || window.event;
                mX = event.pageX;
                dX = $divWrap.offset().left;
                dY = $divWrap.offset().top;
                isDown = true;//鼠标拖拽启
                $(this).addClass("active");
                //修改按钮阴影
                $divMove.css({ "box-shadow": "0 0 8px #666" });
            }
        });
        //鼠标点击松手事件
        $divMove.unbind('mouseup').mouseup(function (e) {
            //var lastX = $this.find(".class").offset().left - dX - 1;// 还没写的 img切图div
            isDown = false;//鼠标拖拽启
            $divMove.removeClass("active");
            //还原按钮阴影
            $divMove.css({ "box-shadow": "0 0 3px #ccc" });
            //returncode(lastX);//返回坐标系
        });
        //滑动事件
        $divWrap.mousemove(function (e) {
            var event = e || window.event;
            var x = event.pageX;//鼠标滑动时的X轴
            if (isDown) {
                if (x > (dX + 30) && x < dX + $(this).width() - 20) {
                    $divMove.css({ "left": (x - dX - 20) + "px" });//div动态位置赋值
                    //$this.find(".class").css({ "left": (x - dX - 30) + "px" });// 还没写的 img切图div
                }
            }
        });


        // 松手需要上传坐标判断，判断失败给出提示并将按钮复位


        //返回坐标系
        function returncode(xpos) {
            opts.callback({ xpos: xpos });
        }

        // 定义刷新参数
        var $pushImg = $this.find(".vCode_push");// 刷新按钮
        // 点击刷新图片
        $pushImg.click(function () {
            var $codeImg = $(".vCode_img");
            // 请求的图片,根据情况来写
            $codeImg.attr("src", 'VCodeImg?_dc=' + new Date().getTime());// 背景图
            // 滑块图 没写
        });
        // 加载触发刷新
        $(function () {
            $pushImg.trigger("click");
        });
    };
})(jQuery);


