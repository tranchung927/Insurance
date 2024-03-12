
const navigation = () => {
  return [
    {
      title: 'About',
      path: '/'
    },
    {
      title: 'Products',
      path: '/products',
      items: [
        {
          title: 'Protection Products',
          path: '/product/protection'
        },
        {
          title: 'Saving Products',
          path: '/product/saving'
        },
        {
          title: 'Education Products',
          path: '/product/education'
        },
        {
          title: 'Investment Products',
          path: '/product/investment'
        },
        {
          title: 'Riders',
          path: '/product/riders'
        },
      ]
    },
    {
      title: 'Service',
      path: '/service',
      items: [
        {
          title: 'Premium Payment',
          path: '/service/insurance-pay'
        },
        {
          title: 'Evaluation process',
          path: '/service/evaluation'
        },
        {
          title: 'Customer care program',
          path: '/service/customer-care'
        },
      ]
    },
    {
      title: 'News',
      path: '/news',
    }
  ]
}

export default navigation
