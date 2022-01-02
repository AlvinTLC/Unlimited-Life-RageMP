var infoped = new Vue({
    el: ".layout",
    data: {
      active: false,
      menu: 0,
    },
    methods: {
      exit: function() {
        mp.trigger('CloseInfoMenu');
        this.menu = 0;
      },
      open: function(id) {
        this.menu = id;
      }
    }
  });
  
  $(function() {
 var badges = {
      'Фракции': {
        'style': 'badge-fractions'
      },
      'FIB': {
        'style': 'badge-fib'
      },
      'LSPD': {
        'style': 'badge-lspd'
      },
      'Мафия': {
        'style': 'badge-mafia'
      },
      'EMS': {
        'style': 'badge-ems'
      },
      'Армия': {
        'style': 'badge-army'
      },
      'Правительство': {
        'style': 'badge-government'
      },
      'Чат': {
        'style': 'badge-chat'
      },
      'Банды': {
        'style': 'badge-ghetto'
      },
      'Автомеханик': {
        'style': 'badge-mechanic'
      },
      'Такси': {
        'style': 'badge-taxi'
      },
      'LSNEWS': {
        'style': 'badge-lsnews'
      },
      'Лидерские': {
        'style': 'badge-lider'
      },
      'Дальнобойщик': {
        'style': 'badge-trucker'
      },
      'Общие': {
        'style': 'badge-general'
      },
      'Основные команды': {
        'style': 'badge-main'
      }
    };
  
    var table = $('#command').DataTable({
      "pageLength": 500,
      autoWidth: true,
      fixedColumns: true,
      ajax: {
        url: 'package://game_resources/interface/assets/json/helpcmd.json',
        dataType: 'json',
      },
      "scrollY": 200,
      "scrollX": false,
      "order": [
        [2, "asc"]
      ],
      "aoColumnDefs": [{
        'bSortable': false,
        'aTargets': [0, 1, 2]
      }],
      columns: [{
          data: 'cmd'
        },
        {
          data: 'descr'
        },
        {
  
          mRender: function(data, type, row) {
            var html = '';
            var tr = row.category.split('|');
            html = html + '<div class="flx">';
            $.each(tr, function(num, value) {
  
              value = $.trim(value);
              if (badges[value]) {
                html = html + '<span class="bg ' + badges[value].style + '">' + value + '</span>';
              } else {
                html = html + '<span class="bg">' + value + '</span>';
              }
  
            });
            html = html + '</div>';
            return html;
          }
        }
      ],
      language: {
        search: "_INPUT_",
        searchPlaceholder: "Поиск",
        zeroRecords: "Команда не найдена",
      }
    });
  
    $(document).on('click', '#go_support', function(e) {
  
      var val = $('#support_answ').val();
      mp.trigger('f10report', val);
      $('#support_answ').val('');
  
    })
  

  
    $('.dataTables_scrollBody').scrollbar({
      scrollx: ''
    });
  
    $('.scrollbar-inner').scrollbar({
      scrollx: ''
    });
  
    var work_active = false,
      fractions = false;
  
    $("#tabs").tabs({
      active: "#tabs-1",
      activate: function(event, ui) {
  
        if (!work_active && ui.newTab.index() == 1) {
          $('#main-slider').liquidSlider({
            firstPanelToLoad: 1,
            hoverArrows: false,
            dynamicArrows: true,
            includeTitle: false,
          });
  
          work_active = true;
  
        } else if (!fractions && ui.newTab.index() == 3) {
          $('#main-fractions').liquidSlider({
            firstPanelToLoad: 1,
            hoverArrows: false,
            dynamicArrows: true,
            includeTitle: false,
          });
          fractions = true;
        }
  
        if (ui.newTab.index() == 2) {
          $($.fn.dataTable.tables(true)).DataTable().columns.adjust();
        }
      }
    });
  });

