import { drawLineChart } from '../Charts/lineChart.js';
import { mesDefault } from './utils.js';

export function renderInadimplenciaChart(inadimplencias) {
    const data = [
        ['Mês', 'Valor de inadimplência'],
    ];
    const mesMap = mesDefault.map(item => ({ ...item }));

    inadimplencias.forEach(inadimplencia => {
        const mes = mesMap.find(item => item.id === inadimplencia.mes_inadimplencia);
        if (mes) {
            mes.valor = inadimplencia.total_inadimplencia;
        }
    });
    
    mesMap.forEach(item => {
        data.push([item.nome, item.valor]);
    });

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(() => drawLineChart('#inadimplenciaChart', data, 'Inadimplência'));
};