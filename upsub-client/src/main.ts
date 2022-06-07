import { createApp } from "vue";
import App from "./App.vue";
import { dashboardFeedHubFactoryKey } from "./injection";
import DashboardFeedHubFactory from "./real-time/DashboardFeedHub";

const apiUrl = "http://localhost:5050";

const app = createApp(App);
app.provide(dashboardFeedHubFactoryKey, new DashboardFeedHubFactory(apiUrl));
app.mount("#app");
