import "@babel/polyfill";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'jquery/dist/jquery.slim.js';
import 'popper.js/dist/umd/popper';
import 'bootstrap/dist/js/bootstrap';
const axios = require('axios');

import Vue from 'vue';

var app = new Vue({
    el: '#app',
    data: {
        submission: {
            name: '',
            occupation: 'Full-stack',
            like: true,
            favouriteFood: "Burgers"
        }
    },
    created: function () {
    },
    methods: {
        submit: function() {
            let submission = this.submission;

            axios({
                method: 'post',
                url: 'https://localhost:44344/api/v1/submissions',
                contentType: 'application/json',
                data: submission,
                responseType: 'json'
            })
              .then(function (response) {
                console.log(response);
              })
              .catch(function (error) {
                console.log(error);
              });
        }
    }
})
