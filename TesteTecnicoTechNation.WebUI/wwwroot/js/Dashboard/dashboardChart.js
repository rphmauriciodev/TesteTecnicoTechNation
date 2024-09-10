import { drawDonutChart } from '../Charts/donutChart.js';

export function renderDashboardChart(total, totalAVencer, dadosGerais) {
        const data = [
            ['Total', 'Valor'],
            ['Valor total das notas emitidas', total],
            ['Valor total das notas a vencer', totalAVencer]
        ];

        dadosGerais.forEach(item => {
            data.push([item.descricao, item.valor_total]);
        });

        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(() => drawDonutChart('#dashboardChart', data, 'Gráfico geral'));
    }
