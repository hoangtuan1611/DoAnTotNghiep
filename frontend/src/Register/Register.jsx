import React, { useEffect, useState } from "react";
import { LockOutlined, UserOutlined } from "@ant-design/icons";
import { Button, Checkbox, Form, Input, Flex } from "antd";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";

function Register() {
  const api = import.meta.env.VITE_API_LECTURER;
  const navigate = useNavigate();

  const onFinish = async (values) => {
    try {
      const result = await axios.post(api, values);
      if (
        result.data.username === values.username &&
        result.data.password === values.password
      ) {
        alert("Đăng ký thành công");
        navigate("/");
      }
    } catch (error) {
      alert("Đăng ký thất bại");
    }
  };

  return (
    <div
      className="relative h-screen"
      style={{ backgroundImage: "url(images/login_bg.jpg)" }}
    >
      <h2
        className="text-2xl font-bold text-center"
        style={{ paddingTop: "2rem", color: "#555" }}
      >
        HỆ THÔNG QUẢN LÝ SINH VIÊN THỰC HÀNH
      </h2>
      <div className="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2">
        <h2
          className="text-2xl font-bold text-center w-2xs"
          style={{ paddingBottom: "2rem", color: "#555" }}
        >
          Đăng Ký
        </h2>
        <Form
          name="register"
          initialValues={{
            remember: true,
          }}
          style={{
            maxWidth: 360,
            margin: "auto",
          }}
          onFinish={onFinish}
        >
          <Form.Item
            name="accountName"
            rules={[
              {
                required: true,
                message: "Please input your Account Name!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Input
              style={{ padding: "0.5rem" }}
              prefix={<UserOutlined />}
              placeholder="Tên tài khoản"
            />
          </Form.Item>
          <Form.Item
            name="username"
            rules={[
              {
                required: true,
                message: "Please input your Username!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Input
              style={{ padding: "0.5rem" }}
              prefix={<UserOutlined />}
              placeholder="Tên đăng nhập"
            />
          </Form.Item>
          <Form.Item
            name="password"
            rules={[
              {
                required: true,
                message: "Please input your Password!",
              },
            ]}
          >
            <Input
              style={{ padding: "0.5rem" }}
              prefix={<LockOutlined />}
              type="password"
              placeholder="Mật khẩu"
            />
          </Form.Item>
          <Form.Item>
            <Button block type="primary" htmlType="submit">
              Đăng ký
            </Button>
            <Link
              to="/"
              style={{
                display: "block",
                textAlign: "center",
                width: "100%",
                marginTop: "0.2rem",
              }}
            >
              Đã có tài khoản? Đăng nhập
            </Link>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
}

export default Register;
