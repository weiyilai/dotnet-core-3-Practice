import Vue from 'vue'
import VueRouter from 'vue-router';
import VueAxios from 'vue-axios';
import axios from 'axios';
import NProgress from 'nprogress';

import App from './App.vue'
import CourseCreate from './components/CourseCreate.vue';
import CourseEdit from './components/CourseEdit.vue';
import CourseIndex from './components/CourseIndex.vue';

import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../node_modules/nprogress/nprogress.css';

Vue.use(VueRouter);
Vue.use(VueAxios, axios);

Vue.config.productionTip = false

const routes = [
    {
        name: 'CourseCreate',
        path: '/course/create',
        component: CourseCreate
    },
    {
        name: 'CourseEdit',
        path: '/course/edit/:id',
        component: CourseEdit
    },
    {
        name: 'CourseIndex',
        path: '/course/index',
        component: CourseIndex
    },
];
const router = new VueRouter({ mode: 'history', routes: routes });

router.beforeResolve((to, from, next) => {
    if (to.name) {
        NProgress.start()
    }
    next()
});

router.afterEach(() => {
    NProgress.done()
});

new Vue({
    render: h => h(App),
    router
}).$mount('#app')
