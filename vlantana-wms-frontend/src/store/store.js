import { createStore } from "vuex";

export default createStore({
  state: {
    selectedCompany: null,
    isClientMode: false,
  },
  mutations: {
    setSelectedCompany(state, payload) {
      state.selectedCompany = payload;
    },
    setIsClientMode(state, payload) {
      state.isClientMode = payload;
    }
  },
  getters: {
    getSelectedCompany(state) {
      return state.selectedCompany;
    },
    getIsClientMode(state) {
      return state.isClientMode;
    }
  },
});