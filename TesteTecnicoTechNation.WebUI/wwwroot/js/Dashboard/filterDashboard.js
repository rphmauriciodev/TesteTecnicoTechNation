import { renderDashboardChart } from './dashboardChart.js';
import { renderInadimplenciaChart } from './inadimplenciaChart.js';
import { renderReceitaChart } from './receitaChart.js';

$(document).ready(function () {
    loadDashboard();
    function toggleDateInput() {
        $('#seletor_data').toggle($('#tipo_periodo').val() === 'M');
        $('#seletor_trimestre').toggle($('#tipo_periodo').val() === 'T');
        $('#seletor_ano').toggle($('#tipo_periodo').val() !== 'M');
    }

    toggleDateInput();

    $('#tipo_periodo').change(toggleDateInput);

    $('#year').on('input', function () {
        const maxLength = 4;
        const value = $(this).val();
        if (value.length > maxLength) {
            $(this).val(value.slice(0, maxLength));
        }
    });

    function getTrimestre() {
        var selectedOption = $('#trimestre').find('option:selected');
        var month = selectedOption.data('month');
        var finalMonth = selectedOption.data('final_month');
        return {
            month: month,
            finalMonth: finalMonth
        }
    }

    $('#trimestre').on('change', function () {
        getTrimestre();
    });

    function loadDashboard(data = {}) {
        $.ajax({
            url: '/Dashboard/GetDashboardData',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: function (response) {
                const dashboardData = response;
                const dadosGerais = dashboardData.dadosGerais;

                renderDashboardChart(dashboardData.total, dashboardData.totalAVencer, dadosGerais);
                renderInadimplenciaChart();
                renderReceitaChart();
            }
        });
    }

    $('#clearFilter').click(function () {
        $('#tipo_periodo').val('A');
        $('#trimestre').prop('selectedIndex', 0); 
        $('#monthDate').val('');
        $('#year').val('');
        toggleDateInput();
        loadDashboard();
    });

    $('#filter').click(function () {
        const tipo_periodo = $('#tipo_periodo').val();
        const year = $('#year').val();
        const monthDate = $('#monthDate').val();
        const trimestre = getTrimestre();

        if (tipo_periodo === 'M' && !monthDate) {
            alert("Selecione um mês válido");
            return;
        }
        if (tipo_periodo !== 'M' && !year) {
            alert("O campo do ano é obrigatório.");
            return;
        }
        let data = {}

        if (tipo_periodo === 'M') {
            var [monthYear, month] = monthDate.split('-');
            data.month = month,
            data.final_month = null,
            data.year = monthYear
        }
        if (tipo_periodo === 'T') {
            data.month = trimestre.month,
            data.final_month = trimestre.finalMonth,
            data.year = year
        }
        if (tipo_periodo === 'A') {
            data.month = null,
            data.final_month = null,
            data.year = year
        }
        
        loadDashboard(data);
    });
});