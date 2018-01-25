/*****
* CONFIGURATION
*/
    //Main navigation
    $.navigation = $('nav > ul.nav');

  $.panelIconOpened = 'icon-arrow-up';
  $.panelIconClosed = 'icon-arrow-down';

  //Default colours
  $.brandPrimary =  '#20a8d8';
  $.brandSuccess =  '#4dbd74';
  $.brandInfo =     '#63c2de';
  $.brandWarning =  '#f8cb00';
  $.brandDanger =   '#f86c6b';

  $.grayDark =      '#2a2c36';
  $.gray =          '#55595c';
  $.grayLight =     '#818a91';
  $.grayLighter =   '#d1d4d7';
  $.grayLightest =  '#f8f9fa';

'use strict';

/****
* MAIN NAVIGATION
*/

$(document).ready(function($){

  // Add class .active to current link
  $.navigation.find('a').each(function(){

    var cUrl = String(window.location).split('?')[0];

    if (cUrl.substr(cUrl.length - 1) == '#') {
      cUrl = cUrl.slice(0,-1);
    }

    if ($($(this))[0].href==cUrl) {
      $(this).addClass('active');

      $(this).parents('ul').add(this).each(function(){
        $(this).parent().addClass('open');
      });
    }
  });

  // Dropdown Menu
  $.navigation.on('click', 'a', function(e){

    if ($.ajaxLoad) {
      e.preventDefault();
    }

    if ($(this).hasClass('nav-dropdown-toggle')) {
      $(this).parent().toggleClass('open');
      resizeBroadcast();
    }

  });

  function resizeBroadcast() {

    var timesRun = 0;
    var interval = setInterval(function(){
      timesRun += 1;
      if(timesRun === 5){
        clearInterval(interval);
      }
      window.dispatchEvent(new Event('resize'));
    }, 62.5);
  }

  /* ---------- Main Menu Open/Close, Min/Full ---------- */
  $('.sidebar-toggler').click(function(){
    $('body').toggleClass('sidebar-hidden');
    resizeBroadcast();
  });

  $('.sidebar-minimizer').click(function(){
    $('body').toggleClass('sidebar-minimized');
    resizeBroadcast();
  });

  $('.brand-minimizer').click(function(){
    $('body').toggleClass('brand-minimized');
  });

  $('.aside-menu-toggler').click(function(){
    $('body').toggleClass('aside-menu-hidden');
    resizeBroadcast();
  });

  $('.mobile-sidebar-toggler').click(function(){
    $('body').toggleClass('sidebar-mobile-show');
    resizeBroadcast();
  });

  $('.sidebar-close').click(function(){
    $('body').toggleClass('sidebar-opened').parent().toggleClass('sidebar-opened');
  });

  /* ---------- Disable moving to top ---------- */
  $('a[href="#"][data-top!=true]').click(function(e){
    e.preventDefault();
  });

});

/****
* CARDS ACTIONS
*/

$(document).on('click', '.card-actions a', function(e){
  e.preventDefault();

  if ($(this).hasClass('btn-close')) {
    $(this).parent().parent().parent().fadeOut();
  } else if ($(this).hasClass('btn-minimize')) {
    var $target = $(this).parent().parent().next('.card-block');
    if (!$(this).hasClass('collapsed')) {
      $('i',$(this)).removeClass($.panelIconOpened).addClass($.panelIconClosed);
    } else {
      $('i',$(this)).removeClass($.panelIconClosed).addClass($.panelIconOpened);
    }

  } else if ($(this).hasClass('btn-setting')) {
    $('#myModal').modal('show');
  }

});

function capitalizeFirstLetter(string) {
  return string.charAt(0).toUpperCase() + string.slice(1);
}

function init(url) {

  /* ---------- Tooltip ---------- */
  $('[rel="tooltip"],[data-rel="tooltip"]').tooltip({"placement":"bottom",delay: { show: 400, hide: 200 }});

  /* ---------- Popover ---------- */
  $('[rel="popover"],[data-rel="popover"],[data-toggle="popover"]').popover();

}

devf = {

    //Is null or empty control
    Ine: function (text) {
        if (text === null || text === undefined || text === "undefined" || text === "") {
            return true;
        }
        return false;
    },

    IsString: function (text) {
        return Object.prototype.toString.call(text) == '[object String]';
    },

    Swal: function (title, text, icon, button) {
        swal({
            title: title,
            text: text,
            icon: icon,
            button: button,
        });
    },

    AjaxHTMLRequest: function (type, data, dataType, url, successFunction, divSelector) {
       
        if (devf.Ine(successFunction)) {
            successFunction = function (returnData) {
                devf.Swal("Title",returnData.Message, returnData.IsSuccess);
            }
        }
        var errorFunction = function (ex) {
            devf.Swal("Error","İşlem sırasında hata oluştu. ( " + ex.statusText + " ) ","error","Close");

        };

        var beforeSendFunction = "";
        var completeFunction = "";

        if (devf.IsString(divSelector)) {
            var element = $(divSelector);
            beforeSendFunction = function () {
                element.LoadingOverlay("show", {
                    fade: [50, 1000]
                });
            };
            completeFunction = function () {
                element.LoadingOverlay("hide", {
                    fade: [50, 1000]
                });
                try {
                    fPosSet(300);
                } catch (err) {
                    console.log(err)
                }
            };

        }
        else {
            var beforeSendFunction = function () {
                $.LoadingOverlay("show", {
                    fade: [500, 1000]
                });
            };
            var completeFunction = function () {
                $.LoadingOverlay("hide", {
                    fade: [500, 1000]
                });
                try {
                    fPosSet(300);
                } catch (err) {
                    console.log(err)
                }
            };
        }
        $.ajax({
            type: type,
            url: url,
            data: data,
            datatype: dataType,
            contentType: false,
            processData: false,
            beforeSend: beforeSendFunction,
            success: successFunction,
            error: errorFunction,
            complete: completeFunction
        });
    }
}