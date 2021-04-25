export const settings = {
    host: ''
};

async function request(url, options) {
    //console.log(url);
    //console.log(options);
    try {
        const response = await fetch(url, options);
        //console.log(response);
        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            const data = await response.json();
            //console.log(data);
            return data;
        } catch (err) {
            //console.log(response);
            return response;
        }

    } catch (error) {
        alert(error.message);
        throw error;
    }

}

function getOptions(method = 'get', body) {
    const options = {
        method,
       // mode: "no-cors",
        headers: {}
    };

    const token = sessionStorage.getItem('authToken');
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }
    if (body) {
        options.headers['Accept']='application/json',
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body)
    }
    //console.log(body);
    return options;

}

export async function get(url) {
    return await request(url, getOptions());
}

export async function post(url, data) {
    //console.log(data);
    return await request(url, getOptions('post', data))
}

export async function put(url, data) {
    return await request(url, getOptions('put', data))
}

export async function del(url) {
    return await request(url, getOptions('delete'))
}

export async function login(email, password) {
   
    const result = await post(settings.host + '/users/login', { email, password });
    //console.log(result);
    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);

    return result;
}

export async function register(email, password) {
    const user = {
        email: email,
        pasword:password
    }
    const result = await post(settings.host + '/users/register', user);

    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);

    return result;
}

export async function logout() {
    const result = await get(settings.host + '/users/logout');

    sessionStorage.removeItem('email');
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');

    return result;
}

