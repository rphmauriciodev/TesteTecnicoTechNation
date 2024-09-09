$(document).ready(function () {

    function toggleDateInput() {
        $('#seletor_data').toggle($('#tipo_data').val() !== 'N');
    }

    toggleDateInput();
    $('#tipo_data').change(toggleDateInput);

    function loadNotes(url, data = {}) {
        $.ajax({
            url: url,
            type: 'GET',
            data: data,
            success: function (response) {
                $('#menuContainer').html(response);
            },
            error: function () {
                alert('Erro ao carregar notas.');
            }
        });
    }

    loadNotes('/NotaFiscal/Listar');

    $('#clearFilter').click(function () {
        $('#status').val('T');
        $('#tipo_data').val('N');
        $('#date').val('');
        toggleDateInput();
        loadNotes('/NotaFiscal/Listar');
    });

    $('#filter').click(function () {
        const status = $('#status').val();
        const tipo_data = $('#tipo_data').val();
        const date = $('#date').val();

        if (tipo_data !== 'N' && !date) {
            alert("O campo da data é obrigatório.");
            return;
        }

        let url = '/NotaFiscal/Listar';
        let data = {};
        if (status !== 'T') data.status = status;
        if (tipo_data !== 'N') {
            data.tipo_data = tipo_data;
            if (date) data.date = date;
        }

        if (status !== 'T' && tipo_data !== 'N' && date) {
            url = '/NotaFiscal/FilterByDateAndStatus';
        } else if (tipo_data !== 'N' && date) {
            url = '/NotaFiscal/FilterByDate';
        } else if (status !== 'T') {
            url = '/NotaFiscal/FilterByStatus';
        }

        loadNotes(url, data);
    });
});
