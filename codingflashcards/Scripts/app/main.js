var flashCard = (function ($) {
    var me = {};
    
    var goHome = function () {
        if (location.href.indexOf("home") !== -1) return false;
        $.mobile.changePage(location.href.split("question")[0] + "home", { transition: "flip" });
        
    };
    
    var hideQuestionAndHint = function () {
        $(".tc-tile.tc-answer.tc-answer-content").addClass('tc-cardover');
        if ($(".tc-tile.tc-header.tc-header-content .tc-toggle").hasClass("hide")) {
            $(".tc-tile.tc-header.tc-header-content .tc-toggle").trigger("click", true);
        }
        if ($(".tc-tile.tc-body.tc-ico").length && $(".tc-tile.tc-body.tc-body-content  .tc-toggle").hasClass("hide")) {
            $(".tc-tile.tc-body.tc-body-content  .tc-toggle").trigger("click", true);
        }
    };
   
   //#region tile events
    var onMenuTileClick = function () {
            $.mobile.navigate($("#container a").attr("href"), { transition: "flip" });
    };

    var onTileClick = function(elem, data) {
        var el = $(this);

        if (el.hasClass("show") && !!data === false) {
            if (el.parent().hasClass("tc-answer")) {
             
                hideQuestionAndHint();
            }
            el.next().slideDown();
            el.removeClass("icon-dnarrow-down show");
            el.addClass("icon-dnarrow-up hide");
        } else {
            el.next().slideUp();
            el.addClass("icon-dnarrow-down show");
            el.removeClass("icon-dnarrow-up hide");
        }
    };

    var onTileQuestionUIClick = function () {
        $(this).slideUp();
        $(this).addClass("question-shown");
        $(".tc-tile.tc-header.tc-header-content").slideDown();
    };

    var onTileHintUIClick = function () {
        if ($(".tc-tile.tc-header.tc-ico").hasClass("question-shown") === false) {
            $(".tc-tile.tc-header.tc-ico").trigger("click");
            return;
        }

        $(".tc-tile.tc-header.tc-header-content .tc-toggle").trigger("click");
        $(".tc-tile.tc-body.tc-body-content").addClass('tc-cardover');
        $(this).slideUp();
        $(this).addClass("hint-shown");
        $(".tc-tile.tc-body.tc-body-content").slideDown();
    };

    var onTileAnswerUIClick = function () {
        var gotHint = $(".tc-tile.tc-body.tc-ico");
        var isHintVisible = gotHint.length ? gotHint.hasClass("hint-shown") : false;

        // user has to look at the question first 
        if ($(".tc-tile.tc-header.tc-ico").hasClass("question-shown") === false) {
            $(".tc-tile.tc-header.tc-ico").trigger("click");
            return;
        }

        // user has to look at the hint first 
        if (gotHint.length && !isHintVisible) {
            gotHint.trigger("click");
            return;
        }
        //before hiding sibblings check if they've been looked at and their expanded
        hideQuestionAndHint();

        $(this).slideUp();
        $(".tc-tile.tc-answer.tc-answer-content").slideDown();

    };

    // Navigation  
    var onBodyLeftSwipe = function(event) {
        event.stopImmediatePropagation();
        if (event.type === "swipeleft") {
            $.mobile.changePage($(this).find("a").attr("href"), { transition: "flip", reloadPage: true });
        }
    };

    var onBodyRightSwipe = function(event) {
       
        event.stopImmediatePropagation();
        if (event.type === "swiperight") window.history.back();
        return false;
    };
    
    me.init = function (data) {
        $(".wrapper div").on("click", onMenuTileClick);
        $(".tc-toggle").on("click", onTileClick);
        $(".tc-tile.tc-header.tc-ico").on("click", onTileQuestionUIClick);
        $(".tc-tile.tc-body.tc-ico").on("click", onTileHintUIClick);
        $(".tc-tile.tc-answer.tc-ico").on("click", onTileAnswerUIClick);
        $(document).on("swipeleft", "#tc-outter", onBodyLeftSwipe);
        $(document).on('swiperight', onBodyRightSwipe);

    };

    return me;
})(jQuery);