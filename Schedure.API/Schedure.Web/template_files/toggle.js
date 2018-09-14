var L10n = {
  vi: {
    required: 'Xin vui lòng không để rỗng',
    email: 'Email không hợp lệ',
    phone: 'Số điện thoại không hợp lệ',
    confirEmail: ''
  },
  en: {
    required: 'This field is required',
    email: 'Email is invalid',
    phone: 'Phone is invalid',
    confirEmail: ''
  },
  fr: {
    required: 'This field is required',
    email: 'Email is invalid',
    phone: 'Phone is invalid',
    confirEmail: ''
  },
  ja: {
    required: 'This field is required',
    email: 'Email is invalid',
    phone: 'Phone is invalid',
    confirEmail: ''
  }
};
var HFH = HFH || {};

HFH = (function(w, $){
  var whichTransitionEvent = function(){
    var t;
    var el = document.createElement('fakeelement');
    var transitions = {
      'transition':'transitionend',
      'OTransition':'oTransitionEnd',
      'MozTransition':'transitionend',
      'WebkitTransition':'webkitTransitionEnd'
    };

    for(t in transitions){
        if( el.style[t] !== undefined ){
            return transitions[t];
        }
    }
  };

  var transitionEvent = whichTransitionEvent();

  var setBackgroundImage = function(){
    var bg = $('[data-background]');
    if(bg.length){
      bg.each(function(){
        $(this).css({
          'background-image': 'url('+ $(this).data('background') +')'
        });
      });
    }
    var bbg = $('#block-aboutworkingathfh, #block-abouthfhclinictrunghoa');
    if(bbg.length){
      bbg.each(function(){
        $(this).find('.field--type-image').css({
          'background-image': 'url('+ $(this).find('img').attr('src') +')'
        });
      });
    }
  };

  var newsSlider = function(){
    var nsl = $('[data-new-slider]');
    if(nsl.length >=3){
      /*nsl.slick({
        infinite: false,
        slidesToShow: 3,
        arrows: true,
        responsive: [
          {
            breakpoint: 1024,
            settings: {
              slidesToShow: 2,
              dots: true,
              arrows: false,
            }
          },
          {
            breakpoint: 769,
            settings: {
              slidesToShow: 1,
              dots: true,
              arrows: false,
            }
          }
        ]
      });*/
    }
  };

  var partnerSlider = function(){
    var nsl = $('[data-partner-slider]');
    if(nsl.length){
      nsl.slick({
        infinite: true,
        slidesToShow: 5,
        arrows: true,
        dots: true,
        responsive: [
          {
            breakpoint: 1280,
            settings: {
              slidesToShow: 4,
              dots: true,
              arrows: true,
            }
          },
          {
            breakpoint: 1024,
            settings: {
              slidesToShow: 3,
              dots: true,
              arrows: false,
            }
          },
          {
            breakpoint: 769,
            settings: {
              slidesToShow: 1,
              arrows: false,
              dots: true
            }
          }
        ]
      });
    }
  };

  var servicesSlider = function(){
    var nsl = $('[data-service-slider]');
    if(nsl.length){
      nsl.slick({
        infinite: true,
        slidesToShow: 2,
        arrows: true,
        dots: true,
        responsive: [
          {
            breakpoint: 769,
            settings: {
              slidesToShow: 1,
              arrows: false
            }
          }
        ]
      });
    }
  };

  var servicesCollectionSlider = function(){
    var scl = $('[data-services-collection-slider]');
    if(scl.length && Detectizr.device.type ==='mobile'){
      scl.slick({
        infinite: true,
        slidesToShow: 1,
        arrows: false,
        dots: true
      });
    }
  };

  var bannerSlider = function(){
    var nsl = $('[data-banner-slider]');
    if(nsl.length){
      // var bg = $('[data-banner-background]', nsl);
      // bg.each(function(){
      //   $(this).closest('.banner-item').css({
      //     'background-image': 'url('+ $(this).data('background') +')'
      //   });
      // });
      nsl.slick({
        infinite: true,
        slidesToShow: 1,
        arrows: true,
        dots: true,
        responsive: [
          {
            breakpoint: 769,
            settings: {
              arrows: false
            }
          }
        ]
      });
    }
  };

  var accordion = function(){
    var cts = $('[data-accordion-content]');
    if(cts.length){
      cts = cts.filter(function(){
        return !$(this).closest('[data-accordion]').find('[data-accordion]').length;
      }).filter(function(){
        return !$(this).closest('.region-pre-header-second').length && !$(this).closest('.main-nav-mobile-wrapper').length;
      });
      // cts.each(function(){
      //   var ct = $(this);
      //   var ac = ct.parents('[data-accordion]');
      //   var trg = $('[data-accordion-trigger]', ac);
      //   var isAnimation = false;
      //   trg.on('click.accordion', function(){
      //     var that = $(this);
      //     var act = $(this).closest('[data-accordion]').find('[data-accordion-content]').eq(trg.index(that));
      //     if(isAnimation){
      //       return;
      //     }
      //     isAnimation = true;
      //     if($(this).hasClass('active')){
      //       $(this).removeClass('active');
      //       act.slideUp('fast', function(){
      //         isAnimation = false;
      //       });
      //     }
      //     else{
      //       $(this).addClass('active');
      //       act.slideDown('fast', function(){
      //         isAnimation = false;
      //       });
      //     }
      //   });
      // });
      var applyAccordion = function(cts){
        cts.parents('[data-accordion]').each(function(){
          var ac = $(this);
          var ct = $('[data-accordion-content]', ac);
          var trg = $('[data-accordion-trigger]', ac);
          var isAnimation = false;
          trg.filter(function(){
            return !$(this).data('click.accordion');
          }).on('click.accordion', function(){
            var that = $(this);
            var act = $(this).closest('[data-accordion]').find('[data-accordion-content]').eq(trg.index(that));
            if(isAnimation){
              return;
            }
            isAnimation = true;
            if($(this).hasClass('active')){
              $(this).removeClass('active');
              act.slideUp('fast', function(){
                isAnimation = false;
                act.css('display','');
              });
            }
            else{
              $(this).addClass('active');
              act.slideDown('fast', function(){
                isAnimation = false;
              });
            }
          });
          trg.data('click.accordion', true);
          if(trg.hasClass('open')){
            trg.trigger('click.accordion');
          }
        });
      };
      applyAccordion(cts);
      // accordion navmobile
      var mbaccd = $('.main-nav-mobile-wrapper [data-accordion-trigger]');
      mbaccd = mbaccd.filter(function(){
        if(!$(this).siblings('[data-accordion-content]').length){
          $(this).hide();
        }
        return !$(this).closest('[data-accordion]').find('[data-accordion]').length;
      });
      applyAccordion(mbaccd);
    }
  };

  var testimonialSlider = function(){
    var nsl = $('[data-testimonials-slider],  [data-detail-slider]');
    if(nsl.length){
      nsl.find('.thumb-info').each(function(){
        var img = $(this).find('img');
        var spt = img.attr('src').split('/');
        $(this).css({
          'background-image': 'url('+ img.attr('src') +')'
        });
        img.attr('src', spt.slice(0, spt.length-1).concat('transparent.png').join('/'));
      });
      nsl.slick({
        infinite: true,
        slidesToShow: 1,
        arrows: false,
        autoplay: true,
        dots: true,
        autoplaySpeed:10000,
        pauseOnHover:true,
      });
    }
  };

  var openMobileNav = function(){
    var hbg = $('[data-hamburger]');
    var fk = hbg.filter('.fake-hamburger');
    var mbn = $('.main-nav-mobile-wrapper');
    var header = $('#pre-header');
    var closembn = $('.close', mbn);
    hbg.on('click.open', function(){
      mbn.css('display', 'block');
      setTimeout(function(){
        mbn.addClass('open');
        $(document.body).addClass('modal-open');
        mbn.css('display', '');
      });
    });
    var callbackFun = function(){
      if(transitionEvent){
        mbn.on(transitionEvent, function() {
          mbn.css('display', '');
          $(document.body).removeClass('modal-open');
          mbn.off(transitionEvent);
        });
      }
      else{
        mbn.css('display', '');
        $(document.body).removeClass('modal-open');
      }
    };
    closembn.on('click.close', function(){
      mbn.css('display', 'block');
      mbn.removeClass('open');
      callbackFun();
    });
    mbn.on('click.close', function(e){
      if($(e.target).is(mbn)){
        closembn.trigger('click.close');
      }
    });
    $(document).on('scroll.hamburger',function(){
      if($(w).scrollTop() >= header.offset().top + header.outerHeight(true)){
        fk.removeClass('slide-in');
      }
      else{
        fk.addClass('slide-in');
      }
    });
  };

  var openSearchPopup = function(){
    var spp = $('[data-search-popup]');
    if(spp.length){
      var pp = $(spp.data('search-popup'));
      var closeSpp = $('.close-btn', pp);
      spp.on('click.open', function(){
        pp.css('display', 'block');
        setTimeout(function(){
          pp.addClass('open');
          $(document.body).addClass('modal-open');
          pp.css('display', '');
        });
      });
      var callbackFun = function(){
        if(transitionEvent){
          pp.on(transitionEvent, function() {
            pp.css('display', '');
            $(document.body).removeClass('modal-open');
            pp.off(transitionEvent);
          });
        }
        else{
          pp.css('display', '');
          $(document.body).removeClass('modal-open');
        }
      };
      closeSpp.on('click.close', function(){
        pp.css('display', 'block');
        pp.removeClass('open');
        callbackFun();
      });
      pp.on('click.close', function(e){
        if($(e.target).is(pp)){
          closeSpp.trigger('click.close');
        }
      });
    }
  };

  var dropdown = function(){
    var drpd = $('[data-dropdown]');
    if(drpd.length){
      var gbl = $();
      drpd.each(function(){
        var that = $(this);
        that.find('a').on('click.dropdown', function(e){
          e.preventDefault();
          if(!that.hasClass('active')){
            gbl.length && gbl.removeClass('active');
            e.stopPropagation();
            that.addClass('active');
            gbl = that;
          }
        });
      });
      $(document).on('click.dropdown', function(){
        if(gbl.length){
          gbl.removeClass('active');
          gbl = $();
        }
      });
    }
  };

  var openVideoPopup = function(){
    var vpp = $('.video-modal');
    if(vpp.length){
      var tvdpp = $('[data-video]');
      var video = vpp.find('.video');
      var clbtn = vpp.find('.close-btn');
      tvdpp.on('click.openVideo', function(e){
        e.preventDefault();
        video.empty();
        video.append('<iframe src="https://www.youtube-nocookie.com/embed/'+ $(this).data('video') +'" width="640" height="360" frameborder="0" allowfullscreen=""></iframe>');
        vpp.css('display', 'block');
        setTimeout(function(){
          vpp.addClass('open');
          $(document.body).addClass('modal-open');
          vpp.css('display', '');
        });
      });

      var callbackFun = function(){
        if(transitionEvent){
          vpp.on(transitionEvent, function() {
            vpp.css('display', '');
            // $(document.body).removeClass('modal-open');
            vpp.off(transitionEvent);
          });
        }
        else{
          vpp.css('display', '');
        }
        $(document.body).removeClass('modal-open');
        video.empty();
      };
      clbtn.on('click.close', function(){
        vpp.css('display', 'block');
        vpp.removeClass('open');
        callbackFun();
      });
      vpp.on('click.close', function(e){
        if($(e.target).is(vpp)){
          clbtn.trigger('click.close');
        }
      });
    }
  };

  var marginMakeAppointment = function(){
    var socialMA = $('.social-make-appointment');
    if(socialMA.length && Detectizr.device.type !=='mobile'){
      var ap = $('.appointment-wrapper', socialMA);
      var ii = 0;
      ap.find('img').each(function(idx){
        var newimg = new Image();
        newimg.onload = function(){
          ii++;
          if(idx === ii-1){
            ap.css('margin-left', -(ap.width() - 25));
          }
        };
        newimg.src = $(this).attr('src');
      });
    }
  };

  var chronologyAnimation = function (){
    var chronology = $('[data-chronology]');
    if(chronology.length){
      var itemAnimation = chronology.find('[data-chronology-animation]');
      var start = false;
      if(Detectizr.device.type !=='mobile'){
        var startAnimation = function(id){
          itemAnimation.eq(id).addClass(itemAnimation.eq(id).data('chronology-animation')).removeClass('invisible');
          if(itemAnimation.eq(id + 1).length){
            setTimeout(function(){
              startAnimation(id+1);
            },1000);
          }
        };
        $(document).on('scroll.chronologyAnimation',function(){
          if($(w).scrollTop() >= (chronology.offset().top - $(w).height()) && !start){
            start = true;
            startAnimation(0);
          }
        }).triggerHandler('scroll.chronologyAnimation');
      }
      else {
        itemAnimation.removeClass('invisible');
      }
    }
  };

  var openNavBarOnMobile = function(){
    var navBar = $('.nav-bar');
    if(navBar.length && Detectizr.device.type !== 'mobile'){
      var navigation = $('.navigation', navBar);
      navigation.on('click.openNav', function(e){
        e.stopPropagation();
        navigation.addClass('active');
      });
      $(document).on('click.openNav', function(){
        navigation.removeClass('active');
      });
      navBar.find('select').prop('selectedIndex', navigation.find('ul li.active').index());
      $('.text-mob', navBar).text(navBar.find('select').children(':selected').text());
    }
    if(Detectizr.device.type === 'mobile'){
      navBar.find('select').on('change.changeUrl',function(){
        window.location = $(this).children(':selected').data('drupal-link-system-path');
      });
      var mobSelect = navBar.find('select').selectmenu({
        open: function() {
          var that = $(this);
          if($(w).width() < 480){
            var data = $(this).data('ui-selectmenu');
            data.menu.width(data.button.outerWidth());
          }
          if(Detectizr.device.type ==='mobile'){
            $(w).on('resize.close', function(){
              that.selectmenu('close');
            });
          }
        },
        close: function() {
          if(Detectizr.device.type ==='mobile'){
            $(w).off('resize.close');
          }
        },
        select: function() {
          window.location = $(this).children(':selected').data('drupal-link-system-path');
        }
      });

      // mobSelect._renderItem = function (ul, item) {
      //   var li = $('<li class="ui-menu-item"></li>');
      //   return li.append('<div tabindex="-1" role="option" class="ui-menu-item-wrapper"><a href="'+ item.element.data('drupal-link-system-path') +'">'+ item.value + '</a></div>')
      //   .appendTo(ul);
      // };
    }
  };

  var tabs = function(){
    var tabs = $('[data-tab]');
    var initTab = function(tab, tg, ct){
      if($(tg, tab).length){
        tab.filter(function(){
          return $(this).data('tab', false);
        }).each(function(){
          var that = $(this);
          var ttg = $(tg, that);
          var tct = $(ct, that);
          var sl = $('select', that);
          ttg.each(function(idx){
            $(this).on('click.tab', function(e){
              e.preventDefault();
              ttg.removeClass('active').eq(idx).addClass('active');
              tct.removeClass('active').eq(idx).addClass('active');
            });
            if($(this).is('.active')){
              sl.prop('selectedIndex', idx);
            }
          });
          if(!ttg.is('.active')){
            ttg.eq(0).addClass('active');
            tct.eq(0).addClass('active');
          }
          sl.on('change.tab', function(){
            ttg.eq($(this).prop('selectedIndex')).trigger('click.tab');
          });
          that.data('tab', false);
        });
      }
    };
    if(tabs.length){
      initTab(tabs, '[data-tab-trigger] span', '[data-tab-content] .tab-item');
      initTab(tabs, '[data-tab-trigger] li', '[data-tab-content] > div');
      // tabs.each(function(){
      //   var that = $(this);
      //   var ttg = $('[data-tab-trigger] span', that);
      //   var tct = $('[data-tab-content] .tab-item', that);
      //   ttg.each(function(idx){
      //     $(this).on('click.tab', function(e){
      //       e.preventDefault();
      //       ttg.removeClass('active').eq(idx).addClass('active');
      //       tct.removeClass('active').eq(idx).addClass('active');
      //     });
      //   });
      // });
    }
  };

  var jobFilter = function(){
    var jobs = $('[data-jobs]');
    if(jobs.length){
      var autoComplete = $('[data-autocomplete]', jobs);
      var dtjob = $('[data-job]', jobs);
      var ul;
      var createTemplate = function(){
        ul = $('<ul class="autocomplete-dropdown"></ul>');
        dtjob.each(function(){
          ul.append('<li data-text="'+ $(this).data('job') +'">'+ $(this).data('job') +'</li>');
        });
        ul = ul.appendTo(autoComplete);
      };
      createTemplate();
      ul.children().on('click.filter', function(){
        var tx = $(this).data('text');
        autoComplete.find('input').val(tx);
        dtjob.css('display', '').each(function(){
          var that = $(this);
          if(tx !== that.data('job')){
            that.css('display', 'none');
          }
        });
      });
      autoComplete.find('.autocomplete').on('click.jobFilter', function(e){
        e.stopPropagation();
        ul.addClass('active');
      });
      $(document).on('click.jobFilter', function(){
        ul.removeClass('active');
      });
    }
  };

  var tabContact = function(){
    var tc = $('[data-tab-contact]');
    if(tc.length){
      tc.each(function(){
        var co = $('[data-contact-option]',tc);
        var to = $('[data-tab-option]',tc);
        var sd = $('.contact-tab', tc);
        var ctl = $('.container-inline', tc);
        var icon = $('.icon', tc);

        if(to.length){
          co.on('change.chooseoption', function(){
            var txt = $(this).data('contact-option');
            to.addClass('hidden').filter(function(){
              return $(this).data('tab-option') === txt;
            }).removeClass('hidden');
          }).triggerHandler('change.chooseoption');
        }
        if(ctl.length){
          co.on('change.chooseoption', function(){
            ctl.addClass('hidden').eq(co.index(this)).removeClass('hidden');
          }).triggerHandler('change.chooseoption');
        }
        if(icon.length){
          icon.on('click.chooseoption', function(){
            $(this).next().find('input').prop('checked', true).trigger('change.chooseoption');
          });
        }

        // if(Detectizr.device.type === 'mobile'){
        //   sd.slick({
        //     infinite: true,
        //     slidesToShow: 1,
        //     arrows: false,
        //     dots: true
        //   });
        // }
      });
    }
  };

  var dateFormat = function(context){
    var formItemDateofbirth =  $('.datefield,[id*="ngay-sinh"],[id*="info-nc"]',context);
    if(formItemDateofbirth.length){
      formItemDateofbirth.each(function(){
        var inpt = $('input', this);
        inpt.attr('maxlength', 100);
        inpt.attr('readonly', true);
        var date = new Date();
        var maxdate = null;
        var yearRange = 'c-100:c+20';
        if( inpt.is('[id*="birth"]') ||
            inpt.is('[id*="ngay-sinh"]')){
          date = null;
          maxdate = new Date();
        } else if (inpt.is('[id*="info-nc"]')) {
            maxdate = null;
            date = null;
        }
        inpt.datepicker({
          dateFormat: 'dd/mm/yy',
          yearRange: yearRange,
          changeMonth: true,
          changeYear: true,
          minDate: date,
          maxDate:maxdate,
        });
      });
    }
  };

  var selectMenu = function(context){
    if(Detectizr.device.type !== 'mobile' || Detectizr.device.type !== 'tablet'){
      $('.webform-submission-form select').selectmenu({
        change: function() {
          $(this).next().removeClass('error');
          $(this).trigger('change.validation');
        }
      });
      var edn = $('#views-exposed-form-workingathfh-page-1 #edit-name');
      if(edn.length){
        edn.selectmenu();
      }
      var selectFindDoctor = $('#views-exposed-form-finddoctor-page-1 select');
      if(selectFindDoctor.length){
        selectFindDoctor.wrap('<div class="fieldset-wrapper"></div>');
        $('#views-exposed-form-finddoctor-page-1 .form-item input').wrap('<div class="fieldset-wrapper"></div>');
        selectFindDoctor.selectmenu();
      }
      var commerceCheckoutFlowSelect = $('#commerce-checkout-flow-multistep-default select');
      if(commerceCheckoutFlowSelect.length){
        commerceCheckoutFlowSelect.selectmenu();
      }
      var benefitInfomationSelect = $('#field-thong-tin-nguoihql select',context);
      if(benefitInfomationSelect.length){
        benefitInfomationSelect.selectmenu();
      }
    }
  };

  var successful = function(){
    var ppwb = $('.popup-webform');
    var pp = $('<div class="modal"><div class="outer"><div class="inner"><span class="close">&nbsp;</span></div></div></div>').appendTo(document.body);
    pp.on('click.closepopup', function(e){
      if(!$(e.target).closest('.inner').length){
        pp.removeClass('open');
      }
    });
    pp.find('.close').on('click.closepopup', function(e){
      pp.removeClass('open');
    });
    pp.on('click.closepopup', 'a.btn', function(e){
      pp.removeClass('open');
    });
    if(ppwb.children().length){
      pp.find('.inner').addClass('success').append(ppwb.html());
      ppwb.hide();
      setTimeout(function(){
        pp.addClass('open');
      }, 200);
    }
  };

  var formValidation = function(){
    // function triggerEvent(element, event){
    //   if (document.createEvent) {
    //     element.dispatchEvent(event);
    //   } else {
    //     element.fireEvent('on' + event.eventType, event);
    //   }
    // }
    var language = $(document.body).data('lang');
    var reg = {
      number: /^\d+$/,
      specialCharater: /([\"<>\(\)\'\%\;\+\&\\*?\~\|#@!])+/,
      email: /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
      character: /[\u0041-\u005A\u0061-\u007A\u00AA\u00B5\u00BA\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u02C1\u02C6-\u02D1\u02E0-\u02E4\u02EC\u02EE\u0370-\u0374\u0376\u0377\u037A-\u037D\u0386\u0388-\u038A\u038C\u038E-\u03A1\u03A3-\u03F5\u03F7-\u0481\u048A-\u0527\u0531-\u0556\u0559\u0561-\u0587\u05D0-\u05EA\u05F0-\u05F2\u0620-\u064A\u066E\u066F\u0671-\u06D3\u06D5\u06E5\u06E6\u06EE\u06EF\u06FA-\u06FC\u06FF\u0710\u0712-\u072F\u074D-\u07A5\u07B1\u07CA-\u07EA\u07F4\u07F5\u07FA\u0800-\u0815\u081A\u0824\u0828\u0840-\u0858\u08A0\u08A2-\u08AC\u0904-\u0939\u093D\u0950\u0958-\u0961\u0971-\u0977\u0979-\u097F\u0985-\u098C\u098F\u0990\u0993-\u09A8\u09AA-\u09B0\u09B2\u09B6-\u09B9\u09BD\u09CE\u09DC\u09DD\u09DF-\u09E1\u09F0\u09F1\u0A05-\u0A0A\u0A0F\u0A10\u0A13-\u0A28\u0A2A-\u0A30\u0A32\u0A33\u0A35\u0A36\u0A38\u0A39\u0A59-\u0A5C\u0A5E\u0A72-\u0A74\u0A85-\u0A8D\u0A8F-\u0A91\u0A93-\u0AA8\u0AAA-\u0AB0\u0AB2\u0AB3\u0AB5-\u0AB9\u0ABD\u0AD0\u0AE0\u0AE1\u0B05-\u0B0C\u0B0F\u0B10\u0B13-\u0B28\u0B2A-\u0B30\u0B32\u0B33\u0B35-\u0B39\u0B3D\u0B5C\u0B5D\u0B5F-\u0B61\u0B71\u0B83\u0B85-\u0B8A\u0B8E-\u0B90\u0B92-\u0B95\u0B99\u0B9A\u0B9C\u0B9E\u0B9F\u0BA3\u0BA4\u0BA8-\u0BAA\u0BAE-\u0BB9\u0BD0\u0C05-\u0C0C\u0C0E-\u0C10\u0C12-\u0C28\u0C2A-\u0C33\u0C35-\u0C39\u0C3D\u0C58\u0C59\u0C60\u0C61\u0C85-\u0C8C\u0C8E-\u0C90\u0C92-\u0CA8\u0CAA-\u0CB3\u0CB5-\u0CB9\u0CBD\u0CDE\u0CE0\u0CE1\u0CF1\u0CF2\u0D05-\u0D0C\u0D0E-\u0D10\u0D12-\u0D3A\u0D3D\u0D4E\u0D60\u0D61\u0D7A-\u0D7F\u0D85-\u0D96\u0D9A-\u0DB1\u0DB3-\u0DBB\u0DBD\u0DC0-\u0DC6\u0E01-\u0E30\u0E32\u0E33\u0E40-\u0E46\u0E81\u0E82\u0E84\u0E87\u0E88\u0E8A\u0E8D\u0E94-\u0E97\u0E99-\u0E9F\u0EA1-\u0EA3\u0EA5\u0EA7\u0EAA\u0EAB\u0EAD-\u0EB0\u0EB2\u0EB3\u0EBD\u0EC0-\u0EC4\u0EC6\u0EDC-\u0EDF\u0F00\u0F40-\u0F47\u0F49-\u0F6C\u0F88-\u0F8C\u1000-\u102A\u103F\u1050-\u1055\u105A-\u105D\u1061\u1065\u1066\u106E-\u1070\u1075-\u1081\u108E\u10A0-\u10C5\u10C7\u10CD\u10D0-\u10FA\u10FC-\u1248\u124A-\u124D\u1250-\u1256\u1258\u125A-\u125D\u1260-\u1288\u128A-\u128D\u1290-\u12B0\u12B2-\u12B5\u12B8-\u12BE\u12C0\u12C2-\u12C5\u12C8-\u12D6\u12D8-\u1310\u1312-\u1315\u1318-\u135A\u1380-\u138F\u13A0-\u13F4\u1401-\u166C\u166F-\u167F\u1681-\u169A\u16A0-\u16EA\u1700-\u170C\u170E-\u1711\u1720-\u1731\u1740-\u1751\u1760-\u176C\u176E-\u1770\u1780-\u17B3\u17D7\u17DC\u1820-\u1877\u1880-\u18A8\u18AA\u18B0-\u18F5\u1900-\u191C\u1950-\u196D\u1970-\u1974\u1980-\u19AB\u19C1-\u19C7\u1A00-\u1A16\u1A20-\u1A54\u1AA7\u1B05-\u1B33\u1B45-\u1B4B\u1B83-\u1BA0\u1BAE\u1BAF\u1BBA-\u1BE5\u1C00-\u1C23\u1C4D-\u1C4F\u1C5A-\u1C7D\u1CE9-\u1CEC\u1CEE-\u1CF1\u1CF5\u1CF6\u1D00-\u1DBF\u1E00-\u1F15\u1F18-\u1F1D\u1F20-\u1F45\u1F48-\u1F4D\u1F50-\u1F57\u1F59\u1F5B\u1F5D\u1F5F-\u1F7D\u1F80-\u1FB4\u1FB6-\u1FBC\u1FBE\u1FC2-\u1FC4\u1FC6-\u1FCC\u1FD0-\u1FD3\u1FD6-\u1FDB\u1FE0-\u1FEC\u1FF2-\u1FF4\u1FF6-\u1FFC\u2071\u207F\u2090-\u209C\u2102\u2107\u210A-\u2113\u2115\u2119-\u211D\u2124\u2126\u2128\u212A-\u212D\u212F-\u2139\u213C-\u213F\u2145-\u2149\u214E\u2183\u2184\u2C00-\u2C2E\u2C30-\u2C5E\u2C60-\u2CE4\u2CEB-\u2CEE\u2CF2\u2CF3\u2D00-\u2D25\u2D27\u2D2D\u2D30-\u2D67\u2D6F\u2D80-\u2D96\u2DA0-\u2DA6\u2DA8-\u2DAE\u2DB0-\u2DB6\u2DB8-\u2DBE\u2DC0-\u2DC6\u2DC8-\u2DCE\u2DD0-\u2DD6\u2DD8-\u2DDE\u2E2F\u3005\u3006\u3031-\u3035\u303B\u303C\u3041-\u3096\u309D-\u309F\u30A1-\u30FA\u30FC-\u30FF\u3105-\u312D\u3131-\u318E\u31A0-\u31BA\u31F0-\u31FF\u3400-\u4DB5\u4E00-\u9FCC\uA000-\uA48C\uA4D0-\uA4FD\uA500-\uA60C\uA610-\uA61F\uA62A\uA62B\uA640-\uA66E\uA67F-\uA697\uA6A0-\uA6E5\uA717-\uA71F\uA722-\uA788\uA78B-\uA78E\uA790-\uA793\uA7A0-\uA7AA\uA7F8-\uA801\uA803-\uA805\uA807-\uA80A\uA80C-\uA822\uA840-\uA873\uA882-\uA8B3\uA8F2-\uA8F7\uA8FB\uA90A-\uA925\uA930-\uA946\uA960-\uA97C\uA984-\uA9B2\uA9CF\uAA00-\uAA28\uAA40-\uAA42\uAA44-\uAA4B\uAA60-\uAA76\uAA7A\uAA80-\uAAAF\uAAB1\uAAB5\uAAB6\uAAB9-\uAABD\uAAC0\uAAC2\uAADB-\uAADD\uAAE0-\uAAEA\uAAF2-\uAAF4\uAB01-\uAB06\uAB09-\uAB0E\uAB11-\uAB16\uAB20-\uAB26\uAB28-\uAB2E\uABC0-\uABE2\uAC00-\uD7A3\uD7B0-\uD7C6\uD7CB-\uD7FB\uF900-\uFA6D\uFA70-\uFAD9\uFB00-\uFB06\uFB13-\uFB17\uFB1D\uFB1F-\uFB28\uFB2A-\uFB36\uFB38-\uFB3C\uFB3E\uFB40\uFB41\uFB43\uFB44\uFB46-\uFBB1\uFBD3-\uFD3D\uFD50-\uFD8F\uFD92-\uFDC7\uFDF0-\uFDFB\uFE70-\uFE74\uFE76-\uFEFC\uFF21-\uFF3A\uFF41-\uFF5A\uFF66-\uFFBE\uFFC2-\uFFC7\uFFCA-\uFFCF\uFFD2-\uFFD7\uFFDA-\uFFDC]+/g
    };

    function Validation(formVal, options){
      this.formVal = formVal;
      this.options = options;
      this.rules = this.options.rules;
      this.valid = true;
      this.elsValidate = [];
      if($(this.formVal).length){
        this.init();
      }
    }
    Validation.prototype.init = function(){
      var that = this;
      that.triggerSubmit = that.formVal.querySelector(that.options.triggerSubmit);
      $(that.triggerSubmit).on('click.submit', function(e){
        that.valid = true;
        $(that.elsValidate.join(), that.formVal).filter(function(){
          return !$(this).is(':hidden') || $(this).is('select');
        }).trigger('change.validation');
        if(!that.valid){
          e.preventDefault();
        }
        if(that.options.onErrors){
          that.options.onErrors($(that.formVal));
        }
      });
      that.populateRules();
    };

    Validation.prototype.detectError = function(rule, value, el, type, message){
      var valid = true;
      var newEl = el;
      var changeError = newEl.data('error');
      if(changeError){
        newEl = newEl.closest('.fieldset-wrapper').find(changeError);
      }
      switch(rule) {
        case 'required':
          valid = !!value;
          break;
        case 'email':
          valid = reg.email.test(value);
          break;
        case 'number':
          valid = reg.number.test(value);
          break;
        case 'character':
          var newReg = new RegExp(reg.character);
          valid = newReg.test(value);
          break;
        case 'specialcharacter':
          valid = !reg.specialCharater.test(value);
          break;
      }
      newEl.removeClass('error');
      newEl.next().text(message);
      if(!valid){
        newEl.addClass('error');
      }
      else{
        if(!this.valid){
          if(this.options.onErrors){
            this.options.onErrors($(this.formVal));
          }
        }
      }
      return valid;
    };

    Validation.prototype.validateRules = function(rules, value, el, type, message){
      var that = this;
      var valid = true;
      for(var i = 0; i < rules.length; i++){
        valid = that.detectError(rules[i], value, el, type, message[i]);
        if(!valid){
          break;
        }
      }
      if(!valid){
        that.valid = valid;
      }
    };
    Validation.prototype.populateRules = function(){
      var that = this;
      var addEvent = function(el, validate, message){
        el.on('change.validation keyup.validation', function(e){
          that.validateRules( validate, this.value, el, e.type, message);
        });
        if(el.data('error')){
          $('<div class="error-mess"></div>').insertAfter(el.closest('.fieldset-wrapper').find(el.data('error')));
        }
        else {
          $('<div class="error-mess"></div>').insertAfter(el);
        }
      };
      for(var i = 0; i < that.rules.length; i ++){
        var el = $(that.rules[i].element, that.formVal);
        if(el.length){
          that.elsValidate.push(that.rules[i].element);
          if(that.rules[i].error){
            el.data('error', that.rules[i].error);
          }
          addEvent(el, that.rules[i].validate.split('|'), that.rules[i].message.split('|'));
        }
      }
    };
    // var makeAnAppointment = $('#webform-submission-make-a-appointment-form');
    var makeAnAppointment = new Validation(document.getElementById('webform-submission-make-a-appointment-form'), {
      triggerSubmit: '#edit-next',
      rules: [
        {
          element: '[name="your_name2"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="your_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="dateofbirth"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="phone_number"]',
          validate: 'required|number',
          message: L10n[language].required + '|' + L10n[language].phone
        },
        {
          element: '[name="email_address2"]',
          validate: 'required|email',
          message: L10n[language].required + '|' + L10n[language].email
        },
        {
          element: '[name="oneday"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="speciality"]',
          validate: 'required',
          error: '#edit-speciality-button',
          message: L10n[language].required
        },
        {
          element: '[name="your_problem"]',
          validate: 'required',
          message: L10n[language].required
        }
      ]
    });
    var leaveusafeedback = new Validation(document.getElementById('webform-submission-leave-us-a-feedback-form'), {
      triggerSubmit: '#edit-submit',
      rules: [
        {
          element: '[name="your_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="last_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="phone_number_3"]',
          validate: 'required|number',
          message: L10n[language].required + '|' + L10n[language].phone
        },
        {
          element: '[name="email_address_2"]',
          validate: 'required|email',
          message: L10n[language].required + '|' + L10n[language].email
        },
        {
          element: '[name="message"]',
          validate: 'required',
          message: L10n[language].required
        }
      ]
    });
    var sendAnInquiry = new Validation(document.getElementById('webform-submission-send-an-inquiry-form'), {
      triggerSubmit: '#edit-submit--2',
      rules: [
        {
          element: '[name="your_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="last_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="phone_number"]',
          validate: 'required|number',
          message: L10n[language].required + '|' + L10n[language].phone
        },
        {
          element: '[name="email_address2"]',
          validate: 'required|email',
          message: L10n[language].required + '|' + L10n[language].email
        },
        {
          element: '[name="your_question"]',
          validate: 'required',
          message: L10n[language].required
        }
      ]
    });
    var sendAnInquiry2 = new Validation(document.getElementById('webform-submission-leave-us-a-feedback2-form'), {
      triggerSubmit: '#edit-submit',
      rules: [
        {
          element: '[name="first_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="last_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="phone_number2"]',
          validate: 'required|number',
          message: L10n[language].required + '|' + L10n[language].phone
        },
        {
          element: '[name="email_address2"]',
          validate: 'required|email',
          message: L10n[language].required + '|' + L10n[language].email
        },
        {
          element: '[name="your_feedback"]',
          validate: 'required',
          message: L10n[language].required
        }
      ]
    });
    var applyJob = new Validation(document.getElementById('webform-submission-apply-job-form'), {
      triggerSubmit: '#edit-submit',
      rules: [
        {
          element: '[name="last_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="first_name"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="email_address"]',
          validate: 'required|email',
          message: L10n[language].required + '|' + L10n[language].email
        },
        {
          element: '[name="phone_number"]',
          validate: 'required|number',
          message: L10n[language].required + '|' + L10n[language].phone
        },
        {
          element: '[name="files[upload_your_cv_and_cover_letter]"]',
          validate: 'required',
          message: L10n[language].required
        }
      ]
    });
    var commerceCheckoutLogin = new Validation(document.getElementById('commerce-checkout-flow-multistep-default'), {
      triggerSubmit: '#edit-login-returning-customer-submit, #edit-actions-next',
      rules: [
        {
          element: '[name="login[returning_customer][name]"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="login[returning_customer][password]"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="contact_information[email]"]',
          validate: 'required|email',
          message: L10n[language].required + '|' + L10n[language].email
        },
        {
          element: '[name="contact_information[email_confirm]"]',
          validate: 'required|email',
          message: L10n[language].required + '|' + L10n[language].email
        },
        {
          element: '[name="payment_information[billing_information][address][0][address][family_name]"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="payment_information[billing_information][address][0][address][given_name]"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="payment_information[billing_information][address][0][address][address_line1]"]',
          validate: 'required',
          message: L10n[language].required
        },
        {
          element: '[name="payment_information[billing_information][address][0][address][locality]"]',
          validate: 'required',
          message: L10n[language].required
        }/*,
        {
          element: '[name="payment_information[billing_information][field_contactmessage][0][value]"]',
          validate: 'required',
          message: L10n[language].required
        }*/
      ]
    });

  };

  var disabledInputCareers = function(){
    var careers = $('[data-careers]');
    if(careers.length){
      $('#webform-submission-apply-job-form #edit-job-title').attr('readonly', true).val(careers.data('careers')).addClass('disabled');
    }
  };

  var setEqualHeight = function(){
    var adminguide = $('.adminguide');
    if(adminguide.length){
      if(Detectizr.device.type !== 'mobile'){
        var block = adminguide.find('.thumb-info');
        var outerBlock = adminguide.find('.item-service');
        var tm = 0;
        $(w).on('resize.setEqualHeight', function(){
          if(tm){
            clearTimeout(tm);
          }
          block.css('height', '');
          tm = setTimeout(function(){
            block.height(outerBlock.height() - 40);
            if($(w).width() <= 975){
              block.css('height', '');
            }
          },100);
        }).triggerHandler('resize.setEqualHeight');
      }
    }
  };

  var readMoreReadLeass = function(){
    var commentItem = $('.comment-item');
    if(commentItem.length){
      commentItem.each(function(){
        var usc = $('.user-comment', this);
        var rm = $('.testimonial-readmore', this);
        var rl = $('.testimonial-readless', this);
        usc.css('max-height', 'none');
        usc.data('max-height', usc.outerHeight());
        usc.css('max-height', '');
        rm.on('click.readmore', function(e){
          e.preventDefault();
          rm.addClass('active');
          usc.css('max-height', usc.data('max-height'));
        });
        rl.on('click.readmore', function(e){
          e.preventDefault();
          rm.removeClass('active');
          usc.css('max-height', '');
        });
      });
    }
  };

  var accordionWorkingHFH = function(context){
    var workingathfh = $('.view-id-workingathfh',context);
    if(workingathfh.length){
      workingathfh.find('.view-grouping').each(function(){
        var tg = $('.view-grouping-header', this);
        var ct = $('.view-grouping-content', this);

        tg.on('click.accordion', function(){
          if($(this).hasClass('active')){
            $(this).removeClass('active');
            ct.slideUp('fast');
          }
          else {
            $(this).addClass('active');
            ct.slideDown('fast');
          }
        });
      });
    }
  };

  var ps_Pos = function (argument) {
      var ps_position = $("#edit-purchased-entity-wrapper").height() + 80;
      $(".package-summary").css({
        top: ps_position+'px',
      });
  }

  var healthCheckup = function (argument) {
    var func1 = function (argument) {
      var _path = $(".field--type-entity-reference .fieldgroup.form-composite.form-wrapper [id^=edit-add-ons] .form-type-checkbox");
      var _totalPath = $(".total-price .total .field--type-commerce-price .field__item");
      _path.find("input[id^=edit-add-ons]").each(function(){
        $(this).prop('checked', false);
        $(this).on('click',function(){
          var _num = $(this).val();
          var _addval = (($(".js-form-item-add-ons-"+_num+" .field--name-price .field__item").text()).slice(1)).replace(/[\.|\,]/g,"");
          var _price = ((_totalPath.text()).slice(1)).replace(/[\.|\,]/g,"");
          console.log(_addval,_price);
          if($(this).is(':checked')){
            var _res = (parseFloat(_addval)+parseFloat(_price));
            var result = _res.toLocaleString(
                      undefined,
                    );
            var _discountPrice = _res*(parseFloat(($(".package-summary .field--name-field-discount .field__item").text()))/100);
            var _preferentialPrice = (_res-_discountPrice).toLocaleString(
                      undefined,
                    );
            //$(".package-summary .public-price .field--name-price").html("đ"+result);
            //$(".package-summary .field--type-commerce-price .field__item").html("đ"+_preferentialPrice);
            _totalPath.html("đ"+_preferentialPrice);
          }
          else{
            var _res = (parseFloat(_price)-parseFloat(_addval));
            var result = _res.toLocaleString(
                      undefined,
                    );
            var _discountPrice = _res*(parseFloat(($(".package-summary .field--name-field-discount .field__item").text()))/100);
            var _preferentialPrice = (_res-_discountPrice).toLocaleString(
                      undefined,
                    );;
            //$(".package-summary .public-price .field--name-price").html("đ"+result);
            //$(".package-summary .field--type-commerce-price .field__item").html("đ"+_preferentialPrice);
            _totalPath.html("đ"+_preferentialPrice);
          }
        });
      });
      //push & replace text
      var _totalPriceTxt = $(".total-price .total p").text();
      $(".total-price .total .field--name-field-new-price.field--type-commerce-price .field__label").html(_totalPriceTxt);
      //dropdown
      $(".field--type-entity-reference [data-drupal-selector^=edit-add-ons] span.fieldset-legend").off();
      $(".field--type-entity-reference [data-drupal-selector^=edit-add-ons]").on('click', 'span.fieldset-legend', function () {
        console.log('click');
        if($(this).hasClass('active')){
          $(this).removeClass('active');
          $(".field--type-entity-reference .commerce-order-item-pado-add-to-cart-form > .fieldgroup.form-composite.form-wrapper .fieldset-wrapper").slideUp(500);
        }
        else{
          $(this).addClass('active');
          $(".field--type-entity-reference .commerce-order-item-pado-add-to-cart-form > .fieldgroup.form-composite.form-wrapper .fieldset-wrapper").slideDown(500);
        }
      });
    }
    func1();

      $(document).on('click',"input[id*=edit-purchased-entity-0-attributes-attribute-delivery-package-more]", function () {
        console.log("radio");
        setTimeout(func1, 1500);
       //$(".field--type-entity-reference [data-drupal-selector^=edit-add-ons]").off( "click", "span.fieldset-legend");
      })
  };


  /* var preLoader = (function(){
    var pp = $();
    var init = function(){
      pp = $('.pre-loader');
      // pp = $('<div class="modal pre-loader"><div class="outer"><div class="inner-loader"><i class="fa fa-spinner fa-spin"></i><img src="/themes/hfh/logo.svg" alt="Home"></div></div></div>').appendTo(document.body);
      $(document.body).addClass('modal-open');
    };
    var complete = function(){
      $(document.body).removeClass('modal-open');
      if(transitionEvent){
        pp.addClass('fadeOut');
        setTimeout(function(){
          // $(document.body).removeClass('modal-open');
          // pp.on('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function(event) {
          //   pp.remove();
          //   pp.off('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend');
          // });
          // pp.on(transitionEvent, function() {
          //   // $(document.body).addClass('animated').addClass('fadeIn');
          //   pp.off(transitionEvent);
          // });
          pp.remove();
        }, 1500);
      }
      else{
        pp.remove();
      }
    };
    return {
      init: init,
      complete: complete
    };
  })(); */
  var setCartPage = function(){
    // Remove order item
    $(".view-commerce-cart-form .views-table td.views-field-remove-button > div").on('click', function (argument) {
      $(this).find('.delete-order-item').trigger("click");
    });
    // Scroll to cart block when page init
    var cartBlock = $('.path-cart #block-hfh-content');
    if (cartBlock.length) {
      var topPos = $(cartBlock).offset().top;
			$('html,body').delay(100).animate({
				scrollTop: topPos
			}, 300);
    }
  };

  var setCheckoutPage = function(context){
    if ($('.layout-region-checkout-main').length) {
      
      // Move contact Email to payment infomation when anonymous user checkout
      $('.layout-region-checkout-main > #edit-contact-information').hide(0);
      $('.field--type-address #edit-contact-information',context).remove();
      $('.layout-region-checkout-main > #edit-contact-information').clone().prependTo('.field--type-address',context);
      $('.field--type-address #edit-contact-information',context).show();
      $('.field--type-address #edit-contact-information input').change(function(){
        $('.layout-region-checkout-main > #edit-contact-information input').val($(this).val());
        $(this).closest("#edit-contact-information").find('error-mess').remove();
        $(this).removeClass('error');
        if (!$(this).val().match(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)) {
            $(this).addClass('error');
            var language = $(document.body).data('lang');
            $(this).after('<div class="error-mess">'+L10n[language]['email']+'</div>');
        }
      });
            
      // Set placeholder of all form field
      var form = $('#commerce-checkout-flow-multistep-default',context);
      
      if (!form.length) {
        form = $(context).closest('#commerce-checkout-flow-multistep-default');
      }
      $('input[type="text"],textarea,input[type="email"]', form).each(function(){
        var desc = $(this).closest('.form-wrapper').find('.description');
        if (desc.length) {
          $(this).attr('placeholder',desc.text().trim());
        } else {
          $(this).attr('placeholder',$(this).closest('.form-item').find('label').text());
        }
      });
      
      // Move to easy css
      $('.js-form-item-agree-terms-terms-and-conditions',form).appendTo('.layout-region-checkout-main');
      
      
    }  
  };


  var renderField = function(){
    var checkPayer = function (argument) {
      //$("input[id*=field-check-payer-value]").prop('checked', false);
      var _label = $(".field--name-field-check-payer label");
      var _lastname = $("input[autocomplete^=family-name]");
      var _firstname = $("input[autocomplete^=given-name]");
      var mobile = $("input[id*=hfh-phone-number]");
      var _phone = $("input[id*=hfh-order-info-dtlh]");
      var _fullname = $("input[id*=hfh-orderinfofullname]");
      //_fullname.val(null);
      //_phone.val(null);
      //_label.on('click', function(){
      var _this = $("input[id*=field-check-payer-value]");
        if(_this.is(':checked')){
          if(_lastname.val()!='' || _firstname.val()!=''){
            _fullname.val(_lastname.val() +" "+ _firstname.val());
            _fullname.prop('readonly', true);
          }
          if(mobile.val()!=''){
            _phone.val(mobile.val());
            _phone.prop('readonly', true);
          }
        }
        else{
          _fullname.val(null);
          _fullname.prop('readonly', false);
          _phone.val(null);
          _phone.prop('readonly', false);
        }
     // });
    }
    //checkPayer();
      $(document).on('click',"input[id*=field-check-payer-value]", function () {
        checkPayer();
      });

      $(document).on('click',"input[id*=edit-payment-information-payment-method]", function () {
        setTimeout(checkPayer, 1500);
      });
      $(document).on('click',"input[id*=thong-tin-nguoihql-add-more]", function () {
        $(document).off('click',"input[id*=field-check-payer-value]");

      });
      $(document).on('click',"input[id*=actions-remove-button]", function () {
        $(document).off('click',"input[id*=field-check-payer-value]");
      });
  }
  var tableReponsive = function() {
    // Set reponsive on cart page and checkout page
    $('.view-commerce-cart-form .views-table th,.view-commerce-checkout-order-summary .views-table th').each(function(){
      var table = $(this).closest('table');
      table.addClass('table-accordion');
      var index = $(this).index()+1;
      var text = $(this).text();
      $('tbody  tr',table).each(function(){
        var td = $('td:nth-child('+index+')',this);
        td.html('<b class="ui-table-label">'+text+'</b><div class="ui-table-cell">'+td.html()+'</div>');
      });
      
 
      $(this).addClass('ui-table-header');
      table.addClass('ui-reponsive-table');
    });
    $('.table-accordion td:first-child').click(function(){
        $(this).closest('tr').toggleClass('active-row');
    });
  }
  var parkageReponsive = function() {
    var packages = $('.packages');
    $('.package-header .sub-col',packages).each(function(){
      var index = $(this).index()+1;
      var text = $('.desk',this).text();
      console.log(index);
      $('.item-row',packages).each(function(){
        var row = $('.sub-col:nth-child('+index+')',this);
        row.html('<b class="ui-package-label">'+text+'</b><div class="ui-package-cell">'+row.html()+'</div>');
      });
    });
  }
  return {
    setBackgroundImage: setBackgroundImage,
    newsSlider: newsSlider,
    partnerSlider: partnerSlider,
    servicesSlider: servicesSlider,
    bannerSlider: bannerSlider,
    accordion: accordion,
    renderField: renderField,
    testimonialSlider: testimonialSlider,
    openMobileNav: openMobileNav,
    openSearchPopup: openSearchPopup,
    dropdown: dropdown,
    openVideoPopup: openVideoPopup,
    marginMakeAppointment: marginMakeAppointment,
    servicesCollectionSlider: servicesCollectionSlider,
    chronologyAnimation: chronologyAnimation,
    openNavBarOnMobile: openNavBarOnMobile,
    tabs: tabs,
    jobFilter: jobFilter,
    tabContact: tabContact,
    dateFormat: dateFormat,
    selectMenu: selectMenu,
    successful: successful,
    formValidation: formValidation,
    disabledInputCareers: disabledInputCareers,
    setEqualHeight: setEqualHeight,
    readMoreReadLeass: readMoreReadLeass,
    accordionWorkingHFH: accordionWorkingHFH,
    setCartPage:setCartPage,
    setCheckoutPage: setCheckoutPage,
    tableReponsive:tableReponsive,
    parkageReponsive: parkageReponsive,
    //preLoader: preLoader,
    healthCheckup: healthCheckup,
    ps_Pos:ps_Pos,
  };
})(window, jQuery);

jQuery(document).ready(function() {
  //HFH.preLoader.init();
  HFH.setBackgroundImage();
  HFH.newsSlider();
  HFH.partnerSlider();
  HFH.servicesSlider();
  HFH.bannerSlider();
  HFH.accordion();
  HFH.testimonialSlider();
  HFH.openMobileNav();
  HFH.openSearchPopup();
  // HFH.dropdown();
  HFH.openVideoPopup();
  HFH.marginMakeAppointment();
  HFH.servicesCollectionSlider();
  HFH.chronologyAnimation();
  HFH.openNavBarOnMobile();
  HFH.tabs();
  HFH.jobFilter();
  HFH.tabContact();
  HFH.healthCheckup();
  HFH.ps_Pos();

  HFH.setCartPage();
  HFH.renderField();
  HFH.tableReponsive();
  HFH.parkageReponsive();
  HFH.successful();
  HFH.formValidation();
  HFH.disabledInputCareers();
  HFH.setEqualHeight();
  HFH.readMoreReadLeass();
  //HFH.preLoader.complete();
});
// Beheviors trigger on ajax 
Drupal.behaviors.hfh = {
  attach: function (context, settings) {
    HFH.dateFormat(context);
    HFH.accordionWorkingHFH(context);
    HFH.selectMenu(context);
    HFH.setCheckoutPage(context);
  }
};