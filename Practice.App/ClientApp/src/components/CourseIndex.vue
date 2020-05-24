
<template>
    <div>
        <h1>Items</h1>

        <table class="table table-hover">
            <thead>
                <tr>
                    <td>CourseID</td>
                    <td>Title</td>
                    <td>Credits</td>
                    <td>DepartmentID</td>
                    <td></td>
                    <td></td>
                </tr>
            </thead>

            <tbody>
                <tr v-for="item in items" :key="item._id">
                    <td>{{ item.CourseID }}</td>
                    <td>{{ item.Title }}</td>
                    <td>{{ item.Credits }}</td>
                    <td>{{ item.DepartmentID }}</td>
                    <td><router-link :to="{name: 'CourseEdit', params: { id: item.CourseID }}" class="btn btn-primary">Edit</router-link></td>
                    <td><button class="btn btn-danger" v-on:click="deleteItem(item.CourseID)">Delete</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>

    export default {
        data() {
            return {
                items: []
            }
        },

        created: function () {
            this.fetchItems();
        },

        methods: {
            fetchItems() {
                let uri = 'https://localhost:5001/api/course';
                this.axios.get(uri).then((response) => {
                    this.items = response.data;
                });
            },
            deleteItem(id) {
                this.items.splice(id, 1);

                this.axios({
                    method: 'delete',
                    baseURL: 'https://localhost:5001',
                    url: '/api/course/' + id,
                    'Content-Type': 'application/json'
                })
                    .then((result) => { console.log(result); this.fetchItems(); })
                    .catch((err) => { console.error(err) });
            }
        }
    }
</script>