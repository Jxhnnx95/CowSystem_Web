$(document).ready(function () {
    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
    });
    // show the alert
    setTimeout(function () {
        $(".alert").alert('close');
    }, 2000);
   
    //delete confirm
    $('a.delete').confirm({
        type: 'green',
        icon: 'lni lni-trash',
        closeIcon: true,
        animation: 'bottom',
        theme: 'material',
        content: "Se perderá toda la información relacionada a este elemento",
        buttons: {
            eliminar: {
                text: 'Sí, Eliminar', // text for button
                btnClass: 'btn-danger', // class for the button
                action: function () {
                    location.href = this.$target.attr('href');
                }
            },
            cancelar: {
                text: 'Mejor no', // text for button
                btnClass: 'btn-primary' // class for the button
            }

        }
    });

    //datatable global settings
    $.extend(true, $.fn.dataTable.defaults, {
        "filter": true, // this is for disable filter (search box)    
        "orderMulti": false,
        "pageLength": 5,
        "lengthMenu": [[5,10, 25, 50, -1], [5,10, 25, 50, "All"]],
        "autoWidth": true,
        "language":
        {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            },
            "buttons": {
                "copy": "Copiar",
                "colvis": "Visibilidad"
            }

        }
    });

    $("#tablaTipoGanado").DataTable({
        "columns": [
            { "width": "65%" },
            { "width": "15%" },
            { "width": "10%" },
            { "width": "10%" },
        ]
    });

    $("#tablaBitacora").DataTable({
    });
    $("#tablaGasto").DataTable({
    });
    $("#tablaTerneros").DataTable({
    });
    $('#tablaVaca').DataTable({
    });
});
