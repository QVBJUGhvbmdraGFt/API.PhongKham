/*jQuery(document).ready(function($) { 
    $(window).scroll(function() {
        if($(this).scrollTop() != 0) {
            $("#toTop").fadeIn();	
        } else {
            $("#toTop").fadeOut();
        }
    });

    $("#toTop").click(function() {
        $("body,html").animate({scrollTop:0},800);
    });	

});*/


(function ($, Drupal, drupalSettings) {
    Drupal.behaviors.hfh = {
        attach: function (context, settings) {
            // main menu
            //init_main_menu(context);
           // sidebar_toggle();
            // Label to placeholder
			
            $("#block-simplenewssubscription-2 form .field--type-email :input,  .search-page-form :input,  #toggle-sidebar .block-search :input, .block-simplenews :input, form#views-exposed-form-hfh-search-page-page-1 :input, #toggle-sidebar :input").not(':checkbox, :radio').each(function (index, elem) {
                var eId = $(elem).attr("id");
                var label = null;
                if (eId && (label = $(elem).parents("form").find("label[for=" + eId + "]")).length == 1) {
                    $(elem).attr("placeholder", $(label).html());
                    $(label).remove();
                }
            });

            // Search text field placeholder
            $('.sidebar input.form-search').attr('placeholder', Drupal.t('keyword ...'));

            $('.block-search .form-actions, .block-views-exposed-filter-blockblog-blog-page .form-actions').click(function () {

            $(this).parents('form').submit();
            });

            // skill bar
            //skills_animation(context);

            // instagram carousel            

            

        }
    };
})(jQuery, Drupal, drupalSettings);    