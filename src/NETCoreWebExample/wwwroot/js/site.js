// site.js

//Self executing function
(function () {
    //var ele = $("#username");
    //ele.text("Lynart");

    //var main = $("#main");
    //main.on("mouseenter", function() {
    //    main.style = "background-color: #888;";
    //});

    //main.on("mouseleave ", function () {
    //    main.style = "";
    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    var $sidebarAndWWarpper = $("#sidebar,#wrapper");

    //Go find sidebarToggle and find the child i classed fa
    var $icon = $("#sidebarToggle i.fa");
    $("#sidebarToggle").on("click", function () {
        $sidebarAndWWarpper.toggleClass("hide-sidebar");
        if ($sidebarAndWWarpper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        }
    });
})();
