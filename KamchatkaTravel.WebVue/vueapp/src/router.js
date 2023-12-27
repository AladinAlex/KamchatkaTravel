import { createRouter, createWebHistory } from "vue-router"

const routes = [
    {
        path: "/",  
        name: "Index",
        component: () => import("@/pages/Index.vue"),
        meta: {
            title: 'Land in the Ocean - Туры по Камчатке',
            layout: 'default',
        }
    },
    {
        path: "/tour",  
        name: "tour",
        component: () => import("@/pages/Tour.vue"),
        meta: {
            title: 'Land in the Ocean - tour_name',
            layout: 'default',
        }
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