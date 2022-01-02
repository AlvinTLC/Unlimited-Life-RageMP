const hclass = (id, name, title, room) => ({
  id,
  name,
  title,
  room,
}); //1KR
const houseClasses = [
  hclass(0, "Anhänger", "Für das kleine Geld", 1),
  hclass(1, "Econom", "Die minderwertigen Häuser", 1),
  hclass(2, "Econom+", "Na ja, so lala.", 2),
  hclass(3, "Comfort", "Das ist nicht schlecht.", 4),
  hclass(4, "Comfort+", "Und Sie bewegen sich", 5),
  hclass(5, "Premium", "Wow, wow.", 6),
  hclass(6, "Premium+", "Nicht dein Niveau, Darling.", 8),
]
var realtorMenu = new Vue({
  el: '#app',
  data: {
    dialogModal: false,
    dialogNumber: 0,
    dialogChecked: false,
    dialBtn: "Ich bin auf der Suche nach einem Haus.",
    dialBtnCancel: "Ich komme später wieder.",
    active: false,
    classes: houseClasses,
    houses: [[1,1,{},4]],
    street: null,
    crossingRoad: null,
    pageNum: 0,
    selectedClass: null,
    activeClassModal: false,
    modalVisible: false,
    modalFilter: false,
    hclass: null,
    house: null,
    stars: 3,
    maxPrice: null,
    minPrice: null,
    search: '',
    filterPrice(house) {
      if (this.minPrice == null && this.maxPrice == null || this.maxPrice == "" && this.minPrice == "") return true;
      var maxI;
      if (this.maxPrice == "" || this.maxPrice == null) {
        maxI = 100000000000000000000
      } else maxI = this.maxPrice;
      var max = house[2] <= maxI ? true : false;
      if (this.minPrice <= house[2] && max) return true;
      else return false;
    }
  },
  methods: {
    dialogNext() {
      this.dialogNumber++;
      if(this.dialogNumber == 2)
      {
        this.dialogModal = false
        this.active = true
        this.dialogNumber = 0
        return
      }
      this.dialogChecked = true
      this.dialBtn = "Ich möchte sehen"
    },
    dialogCheck() {
      this.dialogChecked = !this.dialogChecked
    },
    dialogCancel() {
      this.dialogModal = false
      this.dialBtn = "Ich bin auf der Suche nach einem Haus."
      mp.trigger("closeRealtorMenu")
    },
    selectClass: function(index) {
      this.selectedClass = index
      this.pageNum = 1
      mp.trigger("SelectHouseClass", index)
    },
    classInfo(hclass) {
      this.hclass = hclass
      this.activeClassModal = true
    },
    showModalFitler() {
      this.modalFilter = !this.modalFilter
    },
    info(house) {
      this.house = house
      mp.trigger("getStreetAndAreaHouse", this.house[3].x, this.house[3].y, this.house[3].z)
      this.modalVisible = true
    },
    setGPS() {
      mp.trigger("buyInfoHome", this.selectedClass - 1, this.house[3].x, this.house[3].y)
      this.resetData()
      this.houses = null
      this.active = false
      //console.log("SUCCESS //1KR")
    },
    cancelmodal() {
      this.activeClassModal = false
      this.modalVisible = false
      this.hclass = null
      this.house = null
      //console.log("CANCEL //1KR")
    },
    cancel: function() {
      this.pageNum == 0 ? (mp.trigger("closeRealtorMenu"), this.resetData(), this.active = false) : this.resetData();
    },
    getCountStar(index, count) {
      console.log(index, count)
	  if(count == 0) return "fa-star-o";
      switch (index) {
        case 0:
          if (count == 1) return "fa-star-half-o";
          else return "fa-star";
        case 1:
          if (count < 3) return "fa-star-o";
          if (count == 3) return "fa-star-half-o";
          else return "fa-star";
          break;
        case 2:
          if (count >= 6) return "fa-star";
          if (count == 5) return "fa-star-half-o";
          else return "fa-star-o";
          break;
      }
    },
    resetData() {
      this.selectedClass = null
      this.houses = []
      this.house = null
      this.pageNum = 0
      this.modalFilter = false
      this.modalVisible = false
      this.activeClassModal = false
      this.search = ''
      this.minPrice = null
      this.maxPrice = null
    },
  },
  computed: {
    filterHouse() {
      return this.houses.filter(house => {
        return house[0].toString().indexOf(this.search) > -1
      })
    },
    isDisabled(){
    	return this.dialogChecked;
    }
  }
})
