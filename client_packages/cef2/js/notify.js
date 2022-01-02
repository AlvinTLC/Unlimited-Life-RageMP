function notify(type, layout, message, time) {
    var types = ['alert', 'error', 'success', 'information', 'warning'];
    var layouts = ['top', 'topLeft', 'topCenter', 'topRight', 'center', 'centerLeft', 'centerRight', 'bottom', 'bottomLeft', 'bottomCenter', 'bottomRight'];
    var icons = ['<i class="flaticon-signs"></i>', '<i class="flaticon-close"></i>', '<i class="flaticon-interface"></i>', '<i class="flaticon-signs"></i>', '<i class="flaticon-danger"></i>']
    message = '<div class="text">'+icons[type]+message+'</div>';
    new Noty({
        type: types[type],
        layout: layouts[layout],
        theme: 'fivestar',
        text: message,
        timeout: time,
        progressBar: true,
        animation: {
            open: 'noty_effects_open',
            close: 'noty_effects_close'
        }
    }).show();
}