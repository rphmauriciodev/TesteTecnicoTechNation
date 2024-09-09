import { drawDonutChart } from '../Charts/donutChart.js';

const data = [
    ['Total', 'Valor'],
    ['Valor total das notas emitidas', 50],
    ['Valor total das notas emitidas sem cobrança feita', 1170],
    ['Valor total das notas vencidas - Inadimplência;', 660],
    ['Valor total das notas a vencer', 1030],
    ['Valor total das notas pagas', 1030],
];

google.charts.setOnLoadCallback(() => drawDonutChart('dashboardChart', data, 'Dashboard'));