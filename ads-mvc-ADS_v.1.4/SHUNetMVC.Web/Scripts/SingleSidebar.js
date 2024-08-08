// Allow CSS transitions when page is loaded
$(function () {
    // ========================================
    //
    // Main navigation
    //
    // ========================================


    // Main navigation
    // -------------------------

    // Add 'active' class to parent list item in all levels
    $('.navigation').find('li.active').parents('li').addClass('active');

    // Hide all nested lists
    $('.navigation').find('li').not('.active, .category-title').has('ul').children('ul').addClass('hidden-ul');

    // Highlight children links
    $('.navigation').find('li').has('ul').children('a').addClass('has-ul');

    // Add active state to all dropdown parent levels
    $('.dropdown-menu:not(.dropdown-content), .dropdown-menu:not(.dropdown-content) .dropdown-submenu').has('li.active').addClass('active').parents('.navbar-nav .dropdown:not(.language-switch), .navbar-nav .dropup:not(.language-switch)').addClass('active');



    // Collapsible functionality
    // -------------------------

    // Main navigation
    $('.navigation-main').find('li').has('ul').children('a').on('click', function (e) {
        e.preventDefault();

        // Collapsible
        $(this).parent('li').not('.disabled').not($('.sidebar-xs').not('.sidebar-xs-indicator').find('.navigation-main').children('li')).toggleClass('active').children('ul').slideToggle(250);

        // Accordion
        if ($('.navigation-main').hasClass('navigation-accordion')) {
            $(this).parent('li').not('.disabled').not($('.sidebar-xs').not('.sidebar-xs-indicator').find('.navigation-main').children('li')).siblings(':has(.has-ul)').removeClass('active').children('ul').slideUp(250);
        }
    });


    // Sidebar controls
    // -------------------------

    // Disable click in disabled navigation items
    $(document).on('click', '.navigation .disabled a', function (e) {
        e.preventDefault();
    });

    // init all tool tip
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
    for (var i = 0; i < tooltipList.length; i++) {
        tooltipList[i].disable();
    }

    // TOGGLE MENU HIDE SHOW ON DESKTOP
    $('.toggle-main-menu').on('click', function (e) {
        e.preventDefault();
        $('body > div').toggleClass('sidebar-collapse-desktop');

        var isEnableTooltip = false;
        if ($('body > div').hasClass('sidebar-collapse-desktop')) {
            isEnableTooltip = true;
        }

        for (var i = 0; i < tooltipList.length; i++) {

            if (isEnableTooltip) {
                tooltipList[i].enable();
            } else {
                tooltipList[i].disable();
            }

        }
    })

    // TOGGLE MENU HIDE SHOW ON MOBILE
    $('.toggle-main-menu-mobile, .mobile-menu-overlay').on('click', function (e) {
        e.preventDefault();
        $('body > div').toggleClass('sidebar-expand-mobile');
        $('body > div').toggleClass('sidebar-collapse-desktop');
        $('body').toggleClass('no-scroll');
    });



    function toggleSidebarClasses() {
        var bodyDiv = document.querySelector('body > div');
        var body = document.querySelector('body');

        if (window.innerWidth <= 768) { // Change 768 to your desired mobile screen width
            bodyDiv.classList.toggle('sidebar-collapse-desktop');
            bodyDiv.classList.remove('sidebar-expand-mobile');
            body.classList.toggle('no-scroll');
        } else {
            bodyDiv.classList.toggle('sidebar-expand-mobile');
            bodyDiv.classList.remove('sidebar-collapse-desktop');
            body.classList.toggle('no-scroll'); 
        }
    }

    // Initial call to set classes based on the screen size
    toggleSidebarClasses();

    // Listen for window resize events
    window.addEventListener('resize', function () {
        toggleSidebarClasses();
    });

});
