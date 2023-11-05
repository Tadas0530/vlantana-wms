import { createStore } from "vuex";

export default createStore({
  state: {
    isSlideSelection: false,
  },
  mutations: {
    toggleSlideSelection(state, payload) {
      state.isSlideSelection = payload;
      console.log(state.isSlideSelection);
    }
  },
  getters: {},
});