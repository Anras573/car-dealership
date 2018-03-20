// Write your JavaScript code.
$('*[data-href]').on('click', function () {
    window.location = $(this).data('href');
    return false;
});
