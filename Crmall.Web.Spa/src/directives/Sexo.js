import Vue from 'vue';

Vue.directive('sexo-enum', {

    bind(el, binding, vnode) {

        if(el.innerHTML.trim() === "0")  {
            el.innerHTML = "Masculino"
            return;
        }

        if(el.innerHTML.trim() === "1")  {
            el.innerHTML = "Feminino"
            return;
        }

        if(el.innerHTML.trim() === "2")  {
            el.innerHTML = "Outro"
            return;
        }
    }
    
});