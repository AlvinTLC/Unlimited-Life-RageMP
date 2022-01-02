const fathers = [
  0,
  1,
  2,
  3,
  4,
  5,
  6,
  7,
  8,
  9,
  10,
  11,
  12,
  13,
  14,
  15,
  16,
  17,
  18,
  19,
  20,
  42,
  43,
  44,
]
const mothers = [
  21,
  22,
  23,
  24,
  25,
  26,
  27,
  28,
  29,
  30,
  31,
  32,
  33,
  34,
  35,
  36,
  37,
  38,
  39,
  40,
  41,
  45,
]
const fatherNames = [
  'Benjamin',
  'Daniel',
  'Joshua',
  'Noah',
  'Andrew',
  'Juan',
  'Alex',
  'Isaac',
  'Evan',
  'Ethan',
  'Vincent',
  'Angel',
  'Diego',
  'Adrian',
  'Gabriel',
  'Michael',
  'Santiago',
  'Kevin',
  'Louis',
  'Samuel',
  'Anthony',
  'Claude',
  'Niko',
  'John',
]
const motherNames = [
  'Hannah',
  'Aubrey',
  'Jasmine',
  'Gisele',
  'Amelia',
  'Isabella',
  'Zoe',
  'Ava',
  'Camila',
  'Violet',
  'Sophia',
  'Evelyn',
  'Nicole',
  'Ashley',
  'Gracie',
  'Brianna',
  'Natalie',
  'Olivia',
  'Elizabeth',
  'Charlotte',
  'Emma',
  'Misty',
]

const hairColorsCSS = [
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
  ['#EA4A8E', '#EF97BB', '#00939B', '#015E81', '#003871', '#3D9F67', '#207A60'],
]

const state = {
  mother: 0,
  father: 0,
  similarity: 0.5,
  skinTone: 0.5,
  hairStyle: 0,
  hairColor: [0, 0],
  clothes: [0, 0, 0],
  age: 18,
  gender: 'male',
  first_name: '',
  second_name: '',
}

$(document).ready(function () {
  //step_1
  $('.selector.arrows > .arrow').click((event) => {
    const type =
      event.target.className.indexOf('right') != -1 ? 'right' : 'left'
    const field = event.target.parentNode.parentNode.id
    switch (field) {
      case 'mother': {
        if (type == 'right') {
          state.mother = state.mother == 21 ? 0 : (state.mother += 1)
        } else {
          state.mother = state.mother == 0 ? 21 : (state.mother -= 1)
        }
        $('#mother > .selector > .name').text(motherNames[state.mother])
        break
      }
      case 'father': {
        if (type == 'right') {
          state.father = state.father == 23 ? 0 : (state.father += 1)
        } else {
          state.father = state.father == 0 ? 23 : (state.father -= 1)
        }
        $('#father > .selector > .name').text(fatherNames[state.father])
        break
      }
    }
    changeParents()
  })
  $('#similarity_range').slider({
    animate: 'slow',
    min: 0,
    max: 10,
    value: state.similarity * 10,
    slide: (event, ui) => {
      state.similarity = ui.value / 10
      changeSimilarity()
    },
  })
  $('#skinTone_range').slider({
    animate: 'slow',
    min: 0,
    max: 10,
    value: state.skinTone * 10,
    slide: (event, ui) => {
      state.skinTone = ui.value / 10
      changeSkinTone()
    },
  })

  //step_2
  $('#hairStyle > .selector > .value').text(state.hairStyle)
  $('#hairStyle_range').slider({
    animate: 'slow',
    min: 0,
    max: 37,
    value: state.hairStyle,
    slide: (event, ui) => {
      state.hairStyle = ui.value
      $('#hairStyle > .selector > .value').text(state.hairStyle)
      changeHairStyle()
    },
  })
  for (let i = 0; i < 8; i++) {
    let content = ''
    for (let k = 0; k < 7; k++) {
      content += `<div style="background: ${hairColorsCSS[i][k]}" id='${i}${k}'></div>`
    }
    $('#hairColor > .content').append(`<div class="row">${content}</div>`)
  }
  $(`#${state.hairColor.join('')}`).addClass('selected')
  $('#hairColor > .content > .row > div').click((event) => {
    $('#hairColor > .content > .row > div').removeClass('selected')
    $(`#${event.target.id}`).addClass('selected')
    state.hairColor = event.target.id.split('')
    changeHairColor()
  })

  //step_3
  $('#first_name > .selector > .status').toggleClass('error')
  $('#second_name > .selector > .status').toggleClass('error')
  $('#first_name > .selector > input').on('input', (event) => {
    changeName('first', event.target.value)
  })
  $('#second_name > .selector > input').on('input', (event) => {
    changeName('second', event.target.value)
  })
  $('#age > .selector > .value').text(state.age)
  $('#age_range').slider({
    animate: 'slow',
    min: 25,
    max: 60,
    value: state.age,
    slide: (event, ui) => {
      $('#age > .selector > .value').text(state.age)
      state.age = ui.value
    },
  })
  $(`#gender > .${state.gender}`).addClass('selected')
  $('#gender > .select').click((event) => {
    if (event.target.className.indexOf('female') != -1) {
      if (state.gender != 'female') state.gender = 'female'
    } else {
      if (state.gender != 'male') state.gender = 'male'
    }
    $(`#gender > .select`).removeClass('selected')
    $(`#gender > .${state.gender}`).addClass('selected')
    changeGender()
  })

  //step_4
  $('#clothes_top > .selector > .value').text(state.clothes[0])
  $('#clothes_top_range').slider({
    animate: 'slow',
    min: 0,
    max: 2,
    value: state.clothes[0],
    slide: (event, ui) => {
      state.clothes[0] = ui.value
      $('#clothes_top > .selector > .value').text(state.clothes[0])
      changeClother('top')
    },
  })
  $('#clothes_bot > .selector > .value').text(state.clothes[1])
  $('#clothes_bot_range').slider({
    animate: 'slow',
    min: 0,
    max: 2,
    value: state.clothes[1],
    slide: (event, ui) => {
      state.clothes[1] = ui.value
      $('#clothes_bot > .selector > .value').text(state.clothes[1])
      changeClother('bot')
    },
  })
  $('#clothes_shoes > .selector > .value').text(state.clothes[2])
  $('#clothes_shoes_range').slider({
    animate: 'slow',
    min: 0,
    max: 2,
    value: state.clothes[2],
    slide: (event, ui) => {
      state.clothes[2] = ui.value
      $('#clothes_shoes > .selector > .value').text(state.clothes[2])
      changeClother('shoes')
    },
  })

  //route
  $('#step_1-next').click(() => {
    $('.step_1').css({ display: 'none' })
    $('.step_2').css({ display: 'flex' })
  })
  $('#step_1-cancel').click(() => {
    mp.trigger('createCharacterExit')
  })
  $('#step_2-next').click(() => {
    $('.step_2').css({ display: 'none' })
    $('.step_3').css({ display: 'flex' })
  })
  $('#step_2-cancel').click(() => {
    $('.step_2').css({ display: 'none' })
    $('.step_1').css({ display: 'flex' })
  })
  $('#step_3-next').click(() => {
    $('.step_3').css({ display: 'none' })
    $('.step_4').css({ display: 'flex' })
  })
  $('#step_3-cancel').click(() => {
    $('.step_3').css({ display: 'none' })
    $('.step_2').css({ display: 'flex' })
  })
  $('#step_4-next').click(() => {
    mp.trigger('characterCreateEnd', state)
  })
  $('#step_4-cancel').click(() => {
    $('.step_4').css({ display: 'none' })
    $('.step_3').css({ display: 'flex' })
  })

  //functions
  //-смена родителей
  const changeParents = () => {
    mp.trigger(
      'editorList',
      JSON.stringify({
        mother: mothers[state.mother],
        father: fathers[state.father],
      })
    )
  }

  //-смена схожести
  const changeSimilarity = () => {
    mp.trigger('createCharacterChangeSimilarity', state.similarity)
  }
  //-смена цвета кожи
  const changeSkinTone = () => {
    mp.trigger('createCharacterChangeSkinTone', state.skinTone)
  }
  //-смена причёски
  const changeHairStyle = () => {
    mp.trigger('createCharacterChangeHairStyle', state.hairStyle)
  }
  //-смена цвета волос
  const changeHairColor = () => {
    mp.trigger('createCharacterChangeHairColor', [
      parseInt(state.hairColor[0]),
      parseInt(state.hairColor[1]),
    ])
  }
  //-смена имени
  const changeName = (type, value) => {
    const test_RegExp = /^[a-zA-Z0-9]{6,16}$/
    if (type == 'first') {
      if (test_RegExp.test(value)) {
        $('#first_name > .selector > .status').removeClass('error')
        $('#first_name > .selector > .status').addClass('success')
      } else {
        $('#first_name > .selector > .status').removeClass('success')
        $('#first_name > .selector > .status').addClass('error')
      }
      state.first_name = value
    } else {
      if (test_RegExp.test(value)) {
        $('#second_name > .selector > .status').removeClass('error')
        $('#second_name > .selector > .status').addClass('success')
      } else {
        $('#second_name > .selector > .status').removeClass('success')
        $('#second_name > .selector > .status').addClass('error')
      }
      state.second_name = value
    }
  }
  //-смена гендера
  const changeGender = () => {
    mp.trigger('characterGender', state.gender) //'male' | 'female' +
  }
  //-смена одежды
  const changeClother = (type) => {
    switch (type) {
      case 'top': {
        mp.trigger('createCharacterChangeClothes', ['top', state.clothes[0]])
        break
      }
      case 'bot': {
        mp.trigger('createCharacterChangeClothes', ['bot', state.clothes[1]])
        break
      }
      case 'shoes': {
        mp.trigger('createCharacterChangeClothes', ['shoes', state.clothes[2]])
        break
      }
    }
  }
})
