// server.js
const express = require('express');
const mongoose = require('mongoose');
const bodyParser = require('body-parser');
const User = require('./models/User'); // A User modell importálása

const app = express();
const PORT = process.env.PORT || 5000;

// Body-parser middleware
app.use(bodyParser.json());

// MongoDB csatlakozás
mongoose.connect('mongodb://localhost:27017/yourDatabaseName', {
  useNewUrlParser: true,
  useUnifiedTopology: true
});

// Regisztrációs végpont
app.post('/register', async (req, res) => {
  try {
    const { username, email, password } = req.body;
    const newUser = new User({ username, email, password }); // Jelszó hashelése ajánlott
    await newUser.save();
    res.status(201).send('User registered successfully');
  } catch (error) {
    console.error('Error during registration:', error);
    res.status(500).send('Error registering the user');
  }
});

app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
