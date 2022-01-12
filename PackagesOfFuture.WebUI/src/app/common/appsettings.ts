const apiUrl = 'https://localhost:5001'

export const AppSettings = {
  apiUrl: apiUrl,
  authEndpoint: `${apiUrl}/auth`,
  packagesEndpoint: `${apiUrl}/packages`,
  userEndpoint: `${apiUrl}/users`,
  servicesEndpoint: `${apiUrl}/services`,
  addressEndpoint: `${apiUrl}/addresses`,
  paymentEndpoint: `${apiUrl}/payments`
}