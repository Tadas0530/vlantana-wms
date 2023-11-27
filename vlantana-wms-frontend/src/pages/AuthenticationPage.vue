
<template>
    <div class="d-flex auth-div justify-content-center align-items-center min-vh-100">
        <form class="shadow p-3 mb-5 bg-body rounded" @submit.prevent="handleCredentials">
            <v-text-field v-if="currentFormType.value === 0" v-model="credentials.name"
                label="Pilnas vardas"></v-text-field>

            <v-text-field type="email" v-model="credentials.email" label="El. paštas"></v-text-field>

            <v-text-field type="password" v-model="credentials.password" label="Slaptažodis"></v-text-field>

            <v-text-field type="password" v-if="currentFormType.value === 0" v-model="credentials.passwordRepeat"
                label="Slaptažodžio pakartojimas"></v-text-field>

            <v-select v-if="currentFormType.value === 0" v-model="credentials.company_id" label="Įmonė" :items="companies"
                item-title="title" item-value="id"></v-select>

            <v-select v-if="currentFormType.value === 0" v-model="credentials.role" label="Pareigos" :items="roles"
                item-title="title" item-value="id">
            </v-select>

            <v-btn color="green-darken-1" class="me-4" type="submit">
                <span class="me-2">
                    {{ currentFormType.text }}
                </span>
                <div v-if="loading" class="spinner-border text-light spinner-border-sm"  role="status">
                </div>
            </v-btn>

            <v-btn color="red-darken-1" @click="handleReset">
                Ištrinti
            </v-btn>

            <v-btn color="yellow-darken-1" class="ms-4" @click="changeAuthAction">
                {{ currentFormType.value === 0 ? formTypes[1].text : formTypes[0].text }}
            </v-btn>
        </form>
    </div>
</template>
 
<script>
import urlProvider from "@/utils/url-provider.js"

export default {
    data() {
        return {
            currentFormType: {
                value: 0,
                text: "Registruotis"
            },
            formTypes: [
                {
                    value: 0,
                    text: "Registruotis"
                }, {
                    value: 1,
                    text: "Prisijungti"
                }
            ],
            credentials: {
                name: "",
                email: "",
                password: "",
                company_id: "",
                role: "",
            },
            passwordRepeat: "",
            companies: [
                { id: 0, title: 'Vlantana' },
                { id: 1, title: 'Vilniaus paukštynas' },
                { id: 2, title: 'Retal' },
                { id: 3, title: 'Baltoji varnele' }
            ],
            roles: [
                { id: 0, title: 'Operatorius' },
                { id: 1, title: 'Klientas' },
                { id: 2, title: 'Vadovas' },
                { id: 3, title: 'Sandėlio darbuotojas' }
            ],
            loading: false,
        }
    },
    methods: {
        handleReset() {
            this.credentials = {
                name: "",
                email: "",
                password: "",
                company: "",
                role: "",
            },
            this.passwordRepeat = ""
        },
        handleCredentials() {
            this.loading = true;
            if (this.currentFormType.value === 1) {
                this.$axios.post(`${urlProvider.getServerEndpoint()}/login`, this.credentials, { withCredentials: true })
                    .then(response => {
                        if (response.data.status === 'success') {
                            localStorage.setItem('user', JSON.stringify(response.data));
                            this.$router.push(localStorage.getItem('lastRoute') ?? '/app/dashboard');
                            this.loading = false;
                        } else {
                            console.log('login failed');
                            this.loading = false;
                        }
                    })
                    .catch(error => {
                        this.loading = false;
                        console.error('Error during login:', error);
                    });
            } else {
                this.$axios.post(`${urlProvider.getServerEndpoint()}/register`, this.credentials, { withCredentials: true })
                    .then(response => {
                        if (response.data.status === 'success') {
                            localStorage.setItem('user', JSON.stringify(response.data));
                            this.$router.push(localStorage.getItem('lastRoute'));
                            this.loading = false;
                        } else {
                            this.loading = false;
                            console.log('login failed');
                        }
                    })
                    .catch(error => {
                        this.loading = false;
                        console.error('Error during login:', error);
                    });
            }
        },
        changeAuthAction() {
            this.currentFormType = this.currentFormType.value === 0 ? this.formTypes[1] : this.formTypes[0]
        }
    }
}
</script>

<style>
.auth-div {
    padding: 1rem;
    border: 1px solid black;
    border-radius: 5px;
}

/* Optional: Adjust the min-height of the flex container if needed */
.min-vh-100 {
    min-height: 100vh;
}
</style>