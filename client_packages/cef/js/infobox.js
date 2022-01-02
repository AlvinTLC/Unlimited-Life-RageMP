var boxdata = [
    `<p>Neueinsteiger</p>
    <p>Willkommen in Los Santos.
    <p>Sie können einen Job im Rathaus bekommen.
    <p>Gewinnen Sie einen Job im Rathaus, indem Sie ein Taxi rufen, auf einen Bus warten oder einen Motorroller mieten.
    <p>Den Führerschein kann man bei einer Fahrschule machen, indem man eine "Fahrprüfung" ablegt.</p>
    <p>Sie können einen Waffenschein bei der Polizei erwerben.</p>
    <br>
    <p>Werke</p>
    <br>
    <p>Der Rasenmäher ist ab Level 0 verfügbar</p>
    <p>Der Elektriker ist ab Stufe 1 verfügbar</p>
    <p>Der Postmann ist ab Ebene 2 verfügbar</p>
    <p>Ein Busfahrer ist ab Ebene 3 verfügbar</p>
    <p>Der Busfahrer ist ab Stufe 3 verfügbar
    <p>Der Taxifahrer ist ab Ebene 3 verfügbar</p>
    <p>Der Verkehrsunfallfahrer ist ab Stufe 4 verfügbar</p>
    <p>Der LKW-Fahrer ist ab Level 5 verfügbar</p>
    <br>
    <p>Befehle</p>
    <br>
    <p>/me [action] - Führen Sie eine Aktion aus, "/me schaut zum Himmel.
    <p>/do [Ereignis] - Beschreibt ein Ereignis, "/do beginnt zu regnen."</p>
    <p>/Versuch [Aktion] - Eine strittige Situation auflösen, "/Versuch das Auto zu reparieren (erfolgreich).
    <p>/buybiz - ein Unternehmen kaufen.</p>
    </p> <p>Fraktions-Chat.</p>
    <p>/eject [player id] - aus dem Auto werfen</p>
    <br>
    <p>Bänder</p>
    <br>
    <p>/capture - Aufzeichnung starten</p>
    <br>
    <p>Mafias</p>
    <br>
    <p>/bizwar - um einen Geschäftskrieg zu beginnen.</p>
    <br>
    <p>Polizei</p>
    <br>
    <p>/Ziehen - aus dem Auto herausziehen.</p>
    <p>/incar - ins Auto setzen.</p>
    <p>/rfp - zur Entlassung aus dem Gefängnis.</p>
    <p>/verhaften - ins Gefängnis stecken.</p>
    <p>/su - um eine Suche abzulegen.</p>
    <p>/pd - Herausforderung annehmen.</p>
    <br>
    <p>Medizin</p>
    <br>
    <p>/heal [id] [price] - heilt den Spieler.</p>
    <p>/medkit [id] [Preis] - Medizinschrank an den Spieler verkaufen.</p>
    <p>/ems - nehmen Sie eine Herausforderung an.</p>
    <br>
    <p>Fahrer</p>
    <br>
    <p>/Aufträge - Liste der Aufträge</p>
    <br>
    <p>Mechanik</p>
    <br>
    <p>/Reparatur - Angebot zur Reparatur</p>
    <br>
    <p>Hilfe</p>
    <br>
    <p>/report - eine Beschwerde über einen Spieler schreiben</p>
    <p>/help - bitten Sie die Server-Administration um Hilfe.</p>

Übersetzt mit www.DeepL.com/Translator (kostenlose Version)`,
]

var infobox = new Vue({
    el: '.infobox',
    data: {
        active: false,
        content: "",
        header: "Test",
    },
    methods: {
        set: function(head, id){
            this.header = head
            this.content = boxdata[id]
            this.active = true
        },
        exit: function(){
            this.active = false
            mp.trigger("ib-exit");
        }
    }
})