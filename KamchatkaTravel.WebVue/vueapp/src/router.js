import { createRouter, createWebHistory } from "vue-router"

const routes = [
    {
        path: "/",  
        name: "Index",
        component: () => import("@/pages/Index.vue"),
        meta: {
            title: 'Land in the Ocean - Туры на Камчатку',
            layout: 'default',
        }
    },
    {
        path: "/tour/:name",  
        name: "tour",
        component: () => import("@/pages/Tour.vue"),
        meta: {
            title: 'Land in the Ocean',
            layout: 'default',
        },
        props: true
    },
    {
        path: "/Privacy",  
        name: "Privacy",
        component: () => import("@/pages/privacy-policy.vue"),
        meta: {
            title: 'Land in the Ocean - Политика конфиденциальности',
            layout: 'default-dart',
        }
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

// router.beforeEach((to, from, next) => { next() })

export default router;  