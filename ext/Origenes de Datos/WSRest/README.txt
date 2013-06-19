Como todo origen de datos, por ahora debe respetarse los nombres de atributos.
Los atributos que hay que configurar en el alta de O.D. son:
- Nombre: nombre del origen de datos (es lo que aparece en la home en el detalle de cada novedad)
- Filtro: es el criterio de busqueda de los videos
- Url: URL del WS

El WS debe devolver una List<NovedadExternaDTO> en formato JSon

Para poder configurar un OD local, se debe apuntar la URL al projecto de Servicios, al WS NovedadesService.
La URL seria:
http://localhost:1616/NovedadesService.svc/rest/Novedades/<ID_SITIO>
