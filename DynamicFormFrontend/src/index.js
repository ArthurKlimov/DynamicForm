import "@babel/polyfill";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'jquery/dist/jquery.slim.js';
import 'popper.js/dist/umd/popper';
import 'bootstrap/dist/js/bootstrap';
const axios = require('axios');

import SubmitComponent from './components/submit-component.vue'

import Vue from 'vue';

var app = new Vue({
    el: '#app',
    data: {
      components: {
        'submit-component': submitComponent
      }
    },
})
