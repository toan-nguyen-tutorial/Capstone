const jwt = require('jsonwebtoken');
const User = require('../models/User');

const requireAuth = (req, res, next) => {
    const token = req.cookies.jwt;

    //check json web token exists & is verified
    if (token) {
        jwt.verify(token, process.env.JWT_SECRET, (err, decodedToken) => {
            if(err) {
                console.log(err.message);
                res.redirect('/login');
            }
            else {
                next();
            }
        });
    }
    else {
        res.redirect('/login');
    }
};

const checkUser =  (req, res, next) => {
    const token = req.cookies.jwt;

    if (token) {
        jwt.verify(token, process.env.JWT_SECRET, async (err, decodedToken) => {
            if(err) {
                console.log(err.message);
                res.locals.user = null;
                next();
            }
            else {
                let user = await User.findById(decodedToken.id);
                res.locals.user = user;
                next();
            }
        });
    }
    else {
         res.locals.user = null;
         next();
    }
};


module.exports = { requireAuth, checkUser };