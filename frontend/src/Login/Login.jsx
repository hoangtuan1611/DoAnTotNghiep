import React from "react";
import { LockOutlined, UserOutlined } from "@ant-design/icons";
import { Button, Checkbox, Form, Input, Flex } from "antd";
import { useNavigate, Link } from "react-router-dom";
import axios from "axios";

function Login() {
  const api = import.meta.env.VITE_API_LECTURER;
  const authen_api = `${api}/login`;
  const navigate = useNavigate();

  const onFinish = async (values) => {
    try {
      const result = await axios.post(authen_api, values);
      if (result.data) {
        localStorage.setItem("Token", result.data.token);
        navigate("/home-page");
      }
    } catch (error) {
      alert("Đăng nhập thất bại");
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
          Đăng Nhập
        </h2>
        <Form
          name="login"
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
              placeholder="Email"
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
            <Flex justify="space-between" align="center">
              <Form.Item name="remember" valuePropName="checked" noStyle>
                <Checkbox>Remember me</Checkbox>
              </Form.Item>
              <a href="" style={{ color: "#555" }}>
                Quên mật khẩu
              </a>
            </Flex>
          </Form.Item>
          <Form.Item>
            <Button block type="primary" htmlType="submit">
              Đăng nhập
            </Button>
            <Link
              to="/register"
              style={{
                display: "block",
                textAlign: "center",
                width: "100%",
                marginTop: "0.2rem",
              }}
            >
              Chưa có tài khoản? Đăng ký
            </Link>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
}

export default Login;
