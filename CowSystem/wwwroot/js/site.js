$(document).ready(function () {
    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
    });
    // show the alert
    setTimeout(function () {
        $(".alert").alert('close');
    }, 2000);



    $("#tablaTipoGanado").DataTable({
        "processing": true, // for show progress bar    
        "serverSide": false, // for process server side    
        "filter": true, // this is for disable filter (search box)    
        "orderMulti": false,
        "autoWidth": false,
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }]

    });
});
