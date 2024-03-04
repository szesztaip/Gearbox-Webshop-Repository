import React from 'react'
import { useNavigate } from "react-router-dom";
import { logout } from "./Login";

export function Kijelentkezes() {
    const navigate = useNavigate();

    return (
      <button
        className="btn btn-danger m-3 float-right"
        onClick={() => {
          logout().finally(() => {
            navigate("/");
          });
        }}
      >
      </button>
    );
}