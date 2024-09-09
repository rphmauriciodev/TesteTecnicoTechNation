$(document).ready(function () {
    const hamBurger = $('.toggle-btn');

    hamBurger.on('click', function () {
        $('#sidebar').toggleClass('expand');
    });

    $('#searchForm').on('submit', function (event) {
        event.preventDefault();
    });

    if (!sessionStorage.getItem('initialized')) {
        sessionStorage.setItem('activeSidebarItem', 'dashboard-menu');
        sessionStorage.setItem('initialized', 'true');
    }

    const activeItemId = sessionStorage.getItem('activeSidebarItem');
    if (activeItemId) {
        $(`#${activeItemId}`).addClass('active');
    }

    $('#sidebar-nav .list-group-item').on('click', function () {
        $('#sidebar-nav .list-group-item').removeClass('active');
        
        $(this).addClass('active');
        
        sessionStorage.setItem('activeSidebarItem', $(this).attr('id'));
    });
});
