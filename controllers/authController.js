const User =  require('../models/User');
const jwt = require('jsonwebtoken');

//Handle Errors
//console.log(Error.errors.email);

//Formating json response
const handleErrors = (err) => {
    console.log(err.message, err.code);
    //console.log(Object.values(err.errors));
    //console.log(err.errors.email.message);
    //console.log(err.errors.email.properties);
    let errors = { email:'', password:'', username:''};
   
    //incorrect email
    if(err.message === 'incorrect email') {
        errors.email = 'that email is not registered';
    }
    //incorrect password
    if(err.message === 'incorrect password') {
        errors.password = 'that password is incorrect';
    }
   
    //Duplicate error code
    if (err.code === 11000){
        errors.email = 'that email is already registered';
        return errors;
    }
    //Validation errors
    if (err.message.includes('user validation failed')){
        Object.values(err.errors).forEach(({properties}) => {
        //console.log(properties);
        // path = 'email', message : 'Please ...' 
           errors[properties.path] = properties.message; 
        });
    }
   
   return errors; 
}

const maxAge = 3 * 24 * 60 * 60;
const createToken = (id) => {
    
    return jwt.sign({ id }, process.env.JWT_SECRET, {
        expiresIn: maxAge,
    });
}

module.exports.signup_get = (req, res) => {
    res.render('signup');
}

module.exports.login_get = (req, res) => {
    res.render('login');
}

module.exports.signup_post = async (req, res) => {
    const { email, password, username } = req.body;
   
    try {
        const user = await User.create({ email, password, username });
        //Create jwt & cookie base on _id & secret key
        const token = createToken(user._id);
        res.cookie('jwt', token, {httpOnly: true, maxAge: maxAge * 1000});
        
        res.status(201).json({user: user._id});
    }
    catch (err) {
        const errors = handleErrors(err);
        
        res.status(400).json({errors});
    }
}

module.exports.login_post = async (req, res) => {
    const { email, password } = req.body;
    
    try {
        const user = await User.login(email, password);
        const token = createToken(user._id);
        res.cookie('jwt', token, {httpOnly: true, maxAge: maxAge * 1000});
        res.status(200).json({user: user._id});
    }
    catch (err) {
        const errors = handleErrors(err);
        res.status(400).json({errors});
    }    
}

module.exports.logout_get = async (req, res) => {
    res.cookie('jwt', '', {maxAge : 1});
    res.redirect('/');
}

