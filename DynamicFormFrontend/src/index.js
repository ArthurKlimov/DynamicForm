import "@babel/polyfill";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'jquery/dist/jquery.slim.js';
import 'popper.js/dist/umd/popper';
import 'bootstrap/dist/js/bootstrap';

import Vue from 'vue';

var app = new Vue({
    el: '#app',
    data: {
        hello: 'Privetiki-vinegretiki'
    },
    created: function () {
        console.log('privet')
    },
    methods: {

    }
})
